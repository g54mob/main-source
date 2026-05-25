using System.Collections.Generic;
using UnityEngine;

public class CharDisplay : MonoBehaviour
{
	public enum MovementEnum
	{
		None = 0,
		IdleHandDown = 1,
		IdleHandUp = 2,
		MovingHandDown = 3,
		MovingHandUp = 4,
		IdleMovingHand = 5
	}

	public enum EyeSpriteEnum
	{
		None = 0,
		Normal = 1,
		Closed = 2,
		Angry = 3,
		Small = 4,
		Happy = 5,
		Up = 6,
		Big = 7
	}

	public enum MouthSpriteEnum
	{
		None = 0,
		Normal = 1,
		OpenSmall = 2,
		Bottom = 3,
		Happy = 4,
		OpenBig = 5,
		Sad = 6
	}

	public enum SideEnum
	{
		Right = 0,
		Left = 1
	}

	public enum LocationEnum
	{
		Outside = 0,
		Inside = 1
	}

	public enum ActionEnum
	{
		None = 0,
		Falling = 1,
		Running = 2,
		RunningWithItem = 3
	}

	private GameObject _body;

	private GameObject _eye;

	private GameObject _mouth;

	private GameObject _rabbit;

	private GameObject _hat;

	private GameObject _questionBubble;

	private AnimationSprite _bodyAnimation;

	private SpriteRenderer _bodySprite;

	private SpriteRenderer _eyeSprite;

	private SpriteRenderer _mouthSprite;

	public List<Sprite> EyeSprites;

	public List<Sprite> MouthSprites;

	public MovementEnum CurrentMovement;

	public EyeSpriteEnum CurrentEye;

	public MouthSpriteEnum CurrentMouth;

	public LocationEnum CurrentLocation;

	public SideEnum CurrentSide;

	public ActionEnum CurrentAction;

	public ParticleSystem HearthPS;

	public static bool HasHat;

	public static bool HasQuestionBubble;

	public static bool HasRelax;

	private bool _ignoreBubble;

	private void Awake()
	{
		_body = base.transform.Find("Body").gameObject;
		_eye = base.transform.Find("Eye").gameObject;
		_mouth = base.transform.Find("Mouth").gameObject;
		_rabbit = base.transform.Find("Rabbit").gameObject;
		_hat = base.transform.Find("Hat").gameObject;
		_questionBubble = base.transform.Find("QuestionBubble").gameObject;
		_rabbit.SetActive(value: false);
		_hat.SetActive(value: false);
		_questionBubble.SetActive(value: false);
		_bodyAnimation = _body.GetComponent<AnimationSprite>();
		_bodySprite = _body.GetComponent<SpriteRenderer>();
		_eyeSprite = _eye.GetComponent<SpriteRenderer>();
		_mouthSprite = _mouth.GetComponent<SpriteRenderer>();
		ChangeDisplay(MovementEnum.IdleHandDown, EyeSpriteEnum.Normal, MouthSpriteEnum.Normal);
		ChangeSide(SideEnum.Left);
	}

	private void Start()
	{
	}

	private void Update()
	{
		_rabbit.SetActive(HasRelax);
		_hat.SetActive(HasHat);
		if (!_ignoreBubble)
		{
			_questionBubble.SetActive(HasQuestionBubble);
		}
	}

	public void ChangeMovement(MovementEnum newMovement, bool forceChange = false)
	{
		if (CurrentMovement != newMovement || forceChange)
		{
			CurrentMovement = newMovement;
			switch (CurrentMovement)
			{
			case MovementEnum.None:
				_bodyAnimation.Play("");
				break;
			case MovementEnum.IdleHandDown:
				_bodyAnimation.Play("IdleHandDown");
				break;
			case MovementEnum.IdleHandUp:
				_bodyAnimation.Play("IdleHandUp");
				break;
			case MovementEnum.MovingHandDown:
				_bodyAnimation.Play("MovingHandDown");
				break;
			case MovementEnum.MovingHandUp:
				_bodyAnimation.Play("MovingHandUp");
				break;
			case MovementEnum.IdleMovingHand:
				_bodyAnimation.Play("IdleMovingHand");
				break;
			}
		}
	}

	public void ChangeEye(EyeSpriteEnum newEye)
	{
		if (CurrentEye != newEye)
		{
			CurrentEye = newEye;
			switch (CurrentEye)
			{
			case EyeSpriteEnum.None:
				_eyeSprite.sprite = null;
				break;
			case EyeSpriteEnum.Normal:
				_eyeSprite.sprite = EyeSprites[0];
				break;
			case EyeSpriteEnum.Closed:
				_eyeSprite.sprite = EyeSprites[1];
				break;
			case EyeSpriteEnum.Angry:
				_eyeSprite.sprite = EyeSprites[2];
				break;
			case EyeSpriteEnum.Small:
				_eyeSprite.sprite = EyeSprites[3];
				break;
			case EyeSpriteEnum.Happy:
				_eyeSprite.sprite = EyeSprites[4];
				break;
			case EyeSpriteEnum.Up:
				_eyeSprite.sprite = EyeSprites[5];
				break;
			}
			CurrentAction = ActionEnum.None;
		}
	}

	public void ChangeMouth(MouthSpriteEnum newMouth)
	{
		if (CurrentMouth != newMouth)
		{
			CurrentMouth = newMouth;
			switch (CurrentMouth)
			{
			case MouthSpriteEnum.None:
				_mouthSprite.sprite = null;
				break;
			case MouthSpriteEnum.Normal:
				_mouthSprite.sprite = MouthSprites[0];
				break;
			case MouthSpriteEnum.OpenSmall:
				_mouthSprite.sprite = MouthSprites[1];
				break;
			case MouthSpriteEnum.Bottom:
				_mouthSprite.sprite = MouthSprites[2];
				break;
			case MouthSpriteEnum.Happy:
				_mouthSprite.sprite = MouthSprites[3];
				break;
			case MouthSpriteEnum.OpenBig:
				_mouthSprite.sprite = MouthSprites[4];
				break;
			case MouthSpriteEnum.Sad:
				_mouthSprite.sprite = MouthSprites[5];
				break;
			}
			CurrentAction = ActionEnum.None;
		}
	}

	public void ChangeSide(SideEnum newSide, bool forceChange = false)
	{
		if (CurrentSide != newSide || forceChange)
		{
			CurrentSide = newSide;
			switch (CurrentSide)
			{
			case SideEnum.Right:
				_bodySprite.flipX = false;
				_eyeSprite.flipX = false;
				_mouthSprite.flipX = false;
				break;
			case SideEnum.Left:
				_bodySprite.flipX = true;
				_eyeSprite.flipX = true;
				_mouthSprite.flipX = true;
				break;
			}
		}
	}

	public void ChangeLocation(LocationEnum newLocation, bool forceChange = false)
	{
		if (CurrentLocation != newLocation || forceChange)
		{
			CurrentLocation = newLocation;
			switch (CurrentLocation)
			{
			case LocationEnum.Outside:
				_bodySprite.sortingLayerName = "GameOutside";
				_eyeSprite.sortingLayerName = "GameOutside";
				_mouthSprite.sortingLayerName = "GameOutside";
				_rabbit.GetComponent<SpriteRenderer>().sortingLayerName = "GameOutside";
				_hat.GetComponent<SpriteRenderer>().sortingLayerName = "GameOutside";
				_questionBubble.GetComponent<SpriteRenderer>().sortingLayerName = "GameOutside";
				break;
			case LocationEnum.Inside:
				_bodySprite.sortingLayerName = "GameInside";
				_eyeSprite.sortingLayerName = "GameInside";
				_mouthSprite.sortingLayerName = "GameInside";
				_rabbit.GetComponent<SpriteRenderer>().sortingLayerName = "GameInside";
				_hat.GetComponent<SpriteRenderer>().sortingLayerName = "GameInside";
				_questionBubble.GetComponent<SpriteRenderer>().sortingLayerName = "GameInside";
				break;
			}
		}
	}

	public void ChangeDisplay(MovementEnum newMovement, EyeSpriteEnum newEye, MouthSpriteEnum newMouth)
	{
		ChangeMovement(newMovement);
		ChangeEye(newEye);
		ChangeMouth(newMouth);
	}

	public void ChangeAction(ActionEnum newAction, bool forceChange = false)
	{
		if (CurrentAction != newAction || forceChange)
		{
			if (newAction == ActionEnum.Falling)
			{
				ChangeDisplay(MovementEnum.MovingHandUp, EyeSpriteEnum.Closed, MouthSpriteEnum.OpenBig);
			}
			CurrentAction = newAction;
		}
	}

	public void IgnoreBubble()
	{
		_ignoreBubble = true;
		_questionBubble.SetActive(value: false);
	}

	public void ShowHearth()
	{
		HearthPS.Play();
	}
}
