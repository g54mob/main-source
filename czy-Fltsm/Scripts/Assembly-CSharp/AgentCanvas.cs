using PajamaLlama.Flotsam.Morale;
using UnityEngine;

public class AgentCanvas : MonoBehaviour
{
	[SerializeField]
	private WorldInteractable _canvas;

	[SerializeField]
	private AgentNameTag _nameTag;

	[SerializeField]
	private WorldInteractable _nameTagWorldInteractable;

	[SerializeField]
	private MoraleWarning _moraleWarning;

	private void Update()
	{
		bool flag = _nameTag.IsActive();
		bool flag2 = flag || _moraleWarning.IsActive();
		_canvas.gameObject.SetActive(flag2);
		if (flag2)
		{
			_canvas.FaceCamera();
			if (flag)
			{
				_nameTagWorldInteractable.ScaleToCamera();
			}
		}
	}
}
