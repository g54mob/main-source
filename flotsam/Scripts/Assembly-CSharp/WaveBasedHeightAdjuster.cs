using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public class WaveBasedHeightAdjuster : MonoBehaviour
{
	[Tooltip("This modifier gets added to the height of the child transforms, on top of the height of the water.")]
	[SerializeField]
	private float _heightModifier = 0.25f;

	[Tooltip("List of all transforms that should have their height readjusted.")]
	[SerializeField]
	private List<Transform> _heightTransforms = new List<Transform>();

	private void Awake()
	{
	}

	private void Update()
	{
		base.transform.eulerAngles = new Vector3(base.transform.parent.eulerAngles.x, base.transform.parent.eulerAngles.y, 0f);
		for (int i = 0; i < _heightTransforms.Count; i++)
		{
			float num = WaterManager.Instance.ReturnWaterHeightOnPoint(_heightTransforms[i].position.x, _heightTransforms[i].position.z);
			_heightTransforms[i].position = _heightTransforms[i].position.SetY(num + _heightModifier);
		}
	}
}
