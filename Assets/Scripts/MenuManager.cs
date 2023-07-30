using UnityEngine; //引用Unity 引擎函示庫
using UnityEngine.SceneManagement;

/// <summary>
/// 遊戲開頭畫面場景
/// </summary>
public class MenuManager : MonoBehaviour
{

	public void StartGame()
	{
		SceneManager.LoadScene("遊戲場景");
	}

	public void QuitGame()
	{
		Time.timeScale = 1;
		Application.Quit();
	}

}
