using FSM;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Game
{
    public static Camera FindCameraFromTheScene(Scene s)
    {
        foreach (GameObject go in s.GetRootGameObjects())
        {
            Camera camera = go.GetComponent<Camera>();
            if (camera != null)
            {
                return camera;
            }
        }
        return null;
    }

    public static StateMachineBase FindStateMachine(Scene s)
    {
        foreach (GameObject go in s.GetRootGameObjects())
        {
            StateMachineBase fsm = go.GetComponent<StateMachineBase>();
            if (fsm != null)
            {
                return fsm;
            }
        }
        return null;
    }
}