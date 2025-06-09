using FSM;
using FSM.Connections;
using FSM.States;
using UnityEngine;

namespace Controllers
{
    public class GameController : ControllerBase
    {
        private StateMachineBase m_stateMachine = null;

        private void Start()
        {
            this.InitScene(this.gameObject.scene);
            this.BuildStateMachine();
            BuildStateMachine();
            m_stateMachine.Play();
        }

        private void BuildStateMachine()
        {
            m_stateMachine = Game.FindStateMachine(this.gameObject.scene);
            InitState initState = new InitState();
            LoadState loadState = new LoadState();
            ToLoadingConnection toloadingConnection = new ToLoadingConnection(m_stateMachine);
            toloadingConnection.m_state = loadState;
            initState.AddConnection(toloadingConnection);
            m_stateMachine.AddParameter(new StateMachineParameter("toload", true));
            m_stateMachine.SetCurrentState(initState);
        }
    }
}