using UnityEngine; //引用Unity 引擎函示庫
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

	public void StartGame()
	{
		SceneManager.LoadScene("遊戲場景");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

}
