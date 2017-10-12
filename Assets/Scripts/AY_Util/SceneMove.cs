using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Scene move action component.
/// </summary>
public class SceneMove : MonoBehaviour
{
    /// <summary>
    /// This value express next scene name.
    /// </summary>
    [SerializeField]
    private string mMoveTo = "SceneName";

    /// <summary>
    /// This is process of scene move.
    /// </summary>
    public void Execute ( )
    {
        Scene isScene = SceneManager.GetSceneByName( mMoveTo );
        if (!isScene.IsValid())
        {
            SceneManager.LoadScene( mMoveTo );
        }

        string errorMSG = "Scene move can read next scene. You should check scene name. ";
        throw new System.Exception( errorMSG );
    }
}
