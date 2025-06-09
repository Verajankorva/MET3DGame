using UnityEngine;
using UnityEngine.SceneManagement;

namespace FSM.States
{
    public class InitState : StateBase
    {
        public override void StartState()
        {
            base.StartState();
            SceneManager.LoadSceneAsync("Loading", LoadSceneMode.Additive);
        }

        public override void RunState()
        {
            base.RunState();

            Scene s = SceneManager.GetSceneByName("Loading");
            if (s.isLoaded)
            {
                //Game.loadingController.ShowScene(true);
                //Game.gameStateMachine.m_moveToLoadingState = true;
            }
        }
    }
}