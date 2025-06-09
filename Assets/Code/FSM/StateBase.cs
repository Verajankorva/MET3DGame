using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

namespace FSM
{    public class StateBase
    {
        public ConnectionBase[] m_connections = null;
        public bool m_running = false;
        public Guid m_id = Guid.Empty;

        public StateBase()
        {
            m_id = Guid.NewGuid();
            Debug.Log(string.Format("Create state {0}", m_id.ToString()));
        }

        public void AddConnection(ConnectionBase connection)
        {
            List<ConnectionBase> connections = null;
            if (m_connections == null)
            {
                connections = new List<ConnectionBase>();
            }
            else
            {
                connections = m_connections.ToList<ConnectionBase>();
            }
            connections.Add(connection);
            m_connections = connections.ToArray();
        }

        public void ClearConnections()
        {
            m_connections = null;
        }

        public virtual void RunState()
        {

        }

        public virtual void StartState()
        {
            Debug.Log(string.Format("Begin state {0}.", this.GetType().Name));
            m_running = true;
        }

        public virtual void EndState()
        {
            Debug.Log(string.Format("End state {0}.", this.GetType().Name));
            m_running = false;
        }
    }
}