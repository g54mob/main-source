using Pug.Sprite;
using UnityEngine;

public class WormSegmentTail : MonoBehaviour
{
	public SnakeBossSegmentSpriteController segmentController;

	public SnakeBossSegmentSpriteController tailController;

	public WaterSimAffector waterSimAffector;

	public Transform waterSimSpherePoint;

	public float waterSimSphereRadius;

	private bool _isTail;

	public SpriteObject spriteObject
	{
		get
		{
			if (!isTail)
			{
				return segmentController.spriteObject;
			}
			return tailController.spriteObject;
		}
	}

	public SnakeBossSegmentSpriteController controller
	{
		get
		{
			if (!isTail)
			{
				return segmentController;
			}
			return tailController;
		}
	}

	public bool isTail
	{
		get
		{
			return _isTail;
		}
		set
		{
			if (_isTail != value)
			{
				_isTail = value;
				segmentController.gameObject.SetActive(!_isTail);
				tailController.gameObject.SetActive(_isTail);
			}
		}
	}
}
