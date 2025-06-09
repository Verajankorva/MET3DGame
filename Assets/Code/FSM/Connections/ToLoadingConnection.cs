using UnityEngine;

namespace FSM.Connections
{
    public class ToLoadingConnection : ConnectionBase
    {
        public ToLoadingConnection(StateMachineBase smb) 
            : base(smb)
        {
        }

        public override bool Condition(StateMachineParameter[] args)
        {
            StateMachineParameter p = GetParameter("toload", args);
            if (p != null)
            {
                if ((bool)p.m_value)
                {
                    return true;
                }
            }
            return false;
        }
    }
}