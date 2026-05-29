using Assets.Source.World.Frames;
using UnityEngine;

public class T4PlasticCharge : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _body;

	private float _maxHeight;

	private ActiveWorldFrame _parent;

	private void Start()
	{
		_maxHeight = _body.size.y;
		_parent = GetComponentInParent<ActiveWorldFrame>();
	}

	private void Update()
	{
		if (_parent.ActiveFrame is T4Plastic t4Plastic)
		{
			_body.size = new Vector2(_body.size.x, t4Plastic.Charge / 10.1f * _maxHeight);
		}
	}
}
