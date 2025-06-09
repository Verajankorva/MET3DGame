using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FSM
{
    public class StateMachineParameter
    {
        public object m_value;
        public string m_name;

        public StateMachineParameter(string name, object value)
        {
            m_name = name;
            m_value = value;
        }
    }

    public class StateMachineBase : MonoBehaviour
    {
        private StateBase m_currentState = null;
        private StateBase m_previousState = null;
        public bool m_running = false;
        public StateMachineParameter[] m_parameters = null;

        public void Play()
        {
            Debug.Log(string.Format("Play state machine {0}", this.GetType().ToString()));
            m_running = true;
        }

        public void Stop()
        {
            Debug.Log(string.Format("Stop state machine {0}", this.GetType().ToString()));
            m_running = false;
        }

        public void SetCurrentState(StateBase s)
        {
            m_previousState = m_currentState;
            m_currentState = s;
        }

        public void Update()
        {
            UpdateStatemachine();
        }

        public void AddParameter(StateMachineParameter v)
        {
            List<StateMachineParameter> pars = null;
            if (m_parameters == null)
            {
                pars = new List<StateMachineParameter>();
            }
            else
            {
                pars = m_parameters.ToList<StateMachineParameter>();
            }
            pars.Add(v);
            m_parameters = pars.ToArray();
        }

        public void UpdateStatemachine()
        {
            if (!m_running)
            {
                return;
            }

            if (m_currentState == null)
            {
                return;
            }

            if (m_previousState != null)
            {
                if (m_previousState.m_running)
                {
                    m_previousState.EndState();
                }
            }

            if (m_currentState.m_running)
            {
                if (m_currentState.m_connections != null)
                {
                    foreach (ConnectionBase c in m_currentState.m_connections)
                    {
                        if (c.Condition(m_parameters))
                        {
                            SetCurrentState(c.m_state);
                        }
                    }
                }
            }
            else
            {
                m_currentState.StartState();
            }
        }
    }
}