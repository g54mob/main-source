using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T9UnshackledWidgetBat : MonoBehaviour
	{
		[SerializeField]
		private float _minX;

		[SerializeField]
		private float _maxX;

		private T9UnshackledWidgetPuzzle _parent;

		private void Awake()
		{
			_parent = GetComponentInParent<T9UnshackledWidgetPuzzle>();
		}

		private void Update()
		{
			if (_parent.PuzzleActive)
			{
				Vector2 mouseWorld = PlayerControls.MouseWorld;
				base.transform.localPosition = new Vector3(Mathf.Clamp(mouseWorld.x - base.transform.parent.position.x, _minX, _maxX), base.transform.localPosition.y, base.transform.localPosition.z);
			}
		}
	}
}
