using System.Collections;
using UnityEngine;

public class Propmaster : MonoBehaviour
{
	private enum State
	{
		None = 0,
		MovingIntoPosition = 1,
		WaitingForUseState = 2,
		InUseState = 3
	}

	private struct MoveInto
	{
		public const float kSpeed = 1f;

		public float startTime;

		public float duration;

		public Vector3 position0;

		public Vector3 position1;

		public Quaternion look0;

		public Quaternion look1;
	}

	private Prop prop;

	private Hand hand;

	private Vector3 standHereVel;

	private State state;

	private MoveInto moveInto;

	private Player player;

	private Quaternion targetLook
	{
		get
		{
			return (!(prop.cannedAnim != null)) ? Quaternion.LookRotation(prop.lookHere.position - (moveInto.position1 - player.footOffset + player.eyeOffset)) : prop.cannedAnim.head.transform.rotation;
		}
	}

	private void Start()
	{
		player = GetComponent<Player>();
		hand = GetComponent<Hand>();
		state = State.None;
	}

	private void FixedUpdate()
	{
		if (prop != null && prop.useInfo.moveIntoPosition)
		{
			player.look = Quaternion.Slerp(player.look, targetLook, 0.1f);
		}
	}

	private void Update()
	{
		if (prop == null)
		{
			return;
		}
		player.DisableInputForOneFrame();
		if (state == State.MovingIntoPosition)
		{
			float num = (Clock.play.time - moveInto.startTime) / moveInto.duration;
			float t = Mathf.SmoothStep(0f, 1f, num);
			Vector3 footPos = Vector3.Lerp(moveInto.position0, moveInto.position1, t);
			if (prop.cannedAnim != null)
			{
				player.footPos = footPos;
			}
			else
			{
				player.MoveToFootPos(Vector3.Lerp(moveInto.position0, moveInto.position1, t));
			}
			if (num >= 1f && (prop.cannedAnim == null || Quaternion.Angle(targetLook, player.look) <= 2f))
			{
				if (prop.cannedAnim != null)
				{
					prop.cannedAnim.Play(player, prop);
					prop.StartReset();
					StartCoroutine(StopUsingHandForCannedAnim());
					prop = null;
				}
				else
				{
					prop.animator.SetBool(prop.useInfo.boolParameterName, true);
					state = State.WaitingForUseState;
				}
			}
		}
		else if (state == State.WaitingForUseState)
		{
			if (prop.useInfo.moveIntoPosition)
			{
				player.MoveToFootPos(prop.standHere.position);
			}
			if (prop.animator.GetCurrentAnimatorStateInfo(0).IsName(prop.useInfo.stateName))
			{
				state = State.InUseState;
				hand.CaptureVelcro();
			}
		}
		else
		{
			if (state != State.InUseState)
			{
				return;
			}
			if (prop.animator.GetCurrentAnimatorStateInfo(0).IsName(prop.useInfo.stateName))
			{
				if ((prop.grip.position - prop.releaseGrip.position).magnitude < 0.001f)
				{
					if (prop.useInfo.moveIntoPosition)
					{
						player.MoveToFootPos(prop.standHere.position);
					}
				}
				else
				{
					hand.StopUsing();
				}
			}
			else
			{
				if (hand.isUsing)
				{
					hand.StopUsing();
				}
				prop.StartReset();
				prop = null;
			}
		}
	}

	public void StartSequence(Prop prop_)
	{
		prop = prop_;
		hand.StartUsing(prop);
		if (prop.useInfo.moveIntoPosition)
		{
			state = State.MovingIntoPosition;
			moveInto.startTime = Clock.play.time;
			moveInto.position0 = player.footPos;
			if (prop.cannedAnim != null)
			{
				prop.cannedAnim.PrepareForPlay(prop);
				moveInto.position1 = prop.cannedAnim.head.transform.position - player.eyeOffset + player.footOffset;
			}
			else
			{
				moveInto.position1 = prop.standHere.position;
			}
			moveInto.duration = Vector3.Distance(moveInto.position0, moveInto.position1) / 1f;
			moveInto.look0 = player.look;
		}
		else
		{
			prop.animator.SetBool(prop.useInfo.boolParameterName, true);
			state = State.WaitingForUseState;
		}
	}

	private IEnumerator StopUsingHandForCannedAnim()
	{
		yield return new WaitForSeconds(1f);
		hand.StopUsing();
	}
}
