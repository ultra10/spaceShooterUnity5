using UnityEngine;
using System.Collections;

public class scrollBG : MonoBehaviour {

	public float scrollSpeed;
	private Vector2 savedOffset;
	
	void Start () {
		savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset ("_MainTex");
	}
	
	void Update () {
		float y = Mathf.Repeat (Time.time * scrollSpeed, 1);
		Vector2 offset = new Vector2 (savedOffset.x, y);
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", offset);
		//float scaleX = Mathf.Cos(Time.time) * 0.5F + 1;
//		float scaleY = Time.time * 0.5F + 1;

		//GetComponent<Renderer>().sharedMaterial.mainTextureScale = new Vector2 (0.15f, 0.1f);
	}
	
	void OnDisable () {
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
	}
}