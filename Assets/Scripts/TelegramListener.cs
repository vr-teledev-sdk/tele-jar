using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class TelegramListener : MonoBehaviour {
    public class Repaint: UnityEvent<Color>
    {
    }

    public Repaint RepaintEvent = new Repaint();

	int lastLength = -1;

    private IEnumerator GetTelegramUpdates()
    {
        while (true)
        {
            UnityWebRequest request = UnityWebRequest.Get(
                "https://api.telegram.org/bot232168269:AAGf8WuWT2lDSmHodxfnnAOieQQ6mQqH-LA/getUpdates");
            yield return request.Send();
            if (request.isError)
                Debug.LogError(request.error);
            else
            {
                string text = request.downloadHandler.text;
                Debug.Log("Received string " + text);
				if (lastLength == -1 || lastLength != text.Length)
                {
					lastLength = text.Length;
					float red = Random.value;
                    float green = Random.value;
                    float blue = Random.value;
                    RepaintEvent.Invoke(new Color(red, green, blue));
                }
            }
            yield return new WaitForSeconds(1);
        }
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(GetTelegramUpdates());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
