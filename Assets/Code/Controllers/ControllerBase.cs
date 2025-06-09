using FSM;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class ControllerBase : MonoBehaviour
    {
        public Camera m_sceneCamera = null;
        public Scene m_scene;

        public void InitScene(Scene s)
        {
            Debug.Log(string.Format("Initialize scene {0}", s.name));

            m_scene = s;
            m_sceneCamera = Game.FindCameraFromTheScene(m_scene);
        }

        public virtual bool Condition(object[] args)
        { 
            return true;
        }
    }
}