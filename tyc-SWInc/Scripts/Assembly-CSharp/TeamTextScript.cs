using UnityEngine;

public class TeamTextScript : MonoBehaviour
{
	public Room Parent;

	public bool InUse;

	public bool Bottom;

	private Renderer rend;

	public Vector3 OrigPos;

	public TextMesh tm;

	private void Start()
	{
		rend = GetComponent<Renderer>();
	}

	private void OnEnable()
	{
		base.transform.rotation = Quaternion.LookRotation(new Vector3(base.transform.position.x - CameraScript.Instance.mainCam.transform.position.x, 0f, base.transform.position.z - CameraScript.Instance.mainCam.transform.position.z));
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		bool flag = InUse && Parent.IsContentVisible();
		if (rend.enabled != flag)
		{
			rend.enabled = flag;
		}
		if (!flag)
		{
			return;
		}
		if (CameraScript.Instance.TopDown)
		{
			base.transform.rotation = Quaternion.Euler(90f, CameraScript.Instance.transform.rotation.eulerAngles.y, 0f);
			if (Bottom)
			{
				base.transform.position = OrigPos - Quaternion.Euler(0f, CameraScript.Instance.transform.rotation.eulerAngles.y, 0f) * Vector3.forward;
			}
		}
		else
		{
			if (Bottom)
			{
				base.transform.position = OrigPos;
			}
			base.transform.rotation = Quaternion.LookRotation(new Vector3(base.transform.position.x - CameraScript.Instance.mainCam.transform.position.x, 0f, base.transform.position.z - CameraScript.Instance.mainCam.transform.position.z));
		}
	}
}
