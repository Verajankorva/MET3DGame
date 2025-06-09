using System;
using UnityEngine;

namespace FSM
{
    public class ConnectionBase
    {
        public StateMachineBase m_stateMachine;
        public StateBase m_state = null;
        public Guid m_id = Guid.Empty;

        public ConnectionBase(StateMachineBase smb)
        {
            m_id = Guid.NewGuid();
            m_stateMachine = smb;
            Debug.Log(string.Format("Create connection {0}", m_id.ToString()));
        }

        public StateMachineParameter GetParameter(string name, StateMachineParameter[] args)
        {
            foreach (StateMachineParameter p in args)
            {
                if (p.m_name == name)
                {
                    return p;
                }
            }
            return null;
        }

        public virtual bool Condition(StateMachineParameter[] args)
        {
            return false;
        }
    }
}