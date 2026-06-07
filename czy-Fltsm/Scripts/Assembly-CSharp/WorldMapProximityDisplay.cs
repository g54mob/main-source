using UnityEngine;

public class WorldMapProximityDisplay : MonoBehaviour
{
	[SerializeField]
	private GameObject _visual;

	[SerializeField]
	private float _range = 225f;

	private float _poweredRange;

	private bool _isActive;

	private void Awake()
	{
		_poweredRange = _range * _range;
		bool isActive = (base.transform.position - GameManager.WorldMapManager.WorldMap.Townheart.Position).sqrMagnitude <= _poweredRange;
		_isActive = isActive;
		_visual.SetActive(_isActive);
	}

	private void Update()
	{
		bool flag = (base.transform.position - GameManager.WorldMapManager.WorldMap.Townheart.Position).sqrMagnitude <= _poweredRange;
		if (flag && !_isActive)
		{
			_isActive = true;
			_visual.transform.localScale = Vector3.zero;
			_visual.SetActive(_isActive);
			Tweener.StartTween(0.5f, EasingFunctions.BounceOut, true, new TransformScaleTweener(_visual.transform, 1f));
		}
		else if (!flag && _isActive)
		{
			_isActive = false;
			Tweener.StartTween(0.5f, EasingFunctions.BounceIn, true, new TransformScaleTweener(_visual.transform, 0f));
		}
	}
}
