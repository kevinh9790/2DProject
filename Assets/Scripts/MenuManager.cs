using UnityEngine; //�ޥ�Unity ������ܮw
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

	public void StartGame()
	{
		SceneManager.LoadScene("�C������");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

}
