using UnityEngine;

public class ShadowImposter : MonoBehaviour
{
	private Renderer ren;

	private void Start()
	{
		ren = GetComponent<Renderer>();
	}

	private void Update()
	{
		Camera mainCamera = Player.instance.mainCamera;
		Vector3 vector = mainCamera.transform.position - base.transform.position;
		float num = Mathf.Abs(vector.x);
		float num2 = Mathf.Abs(vector.y);
		float num3 = QualitySettings.shadowDistance - 9f;
		bool flag = num2 < 2.5f && num > num3;
		ren.enabled = flag;
	}
}
