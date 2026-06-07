using System.Collections.Generic;
using MalbersAnimations.Events;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[AddComponentMenu("Malbers/Animal Controller/Swap Character")]
	public class SwapCharacter : MonoBehaviour
	{
		[Tooltip("Force Fall State if the animal is not grounded")]
		public StateID Fall;

		public List<MAnimal> Characters = new List<MAnimal>();

		public GameObjectEvent OnSwap = new GameObjectEvent();

		private MAnimal currentChar;

		private int currentCharIndex;

		private void OnEnable()
		{
			if (Characters.Count <= 1)
			{
				return;
			}
			for (int i = 1; i < Characters.Count; i++)
			{
				if (Characters[i].gameObject.IsPrefab())
				{
					Characters[i] = Object.Instantiate(Characters[i]);
				}
			}
			Characters[0].gameObject.SetActive(value: true);
			currentChar = Characters[0];
			for (int j = 1; j < Characters.Count; j++)
			{
				Characters[j].gameObject.SetActive(value: false);
			}
			OnSwap.Invoke(currentChar.gameObject);
		}

		public void Swap(int Index)
		{
			int index = Index % Characters.Count;
			MAnimal mAnimal = Characters[index];
			if (currentChar != mAnimal)
			{
				Vector3 rawInputAxis = currentChar.RawInputAxis;
				Swap(currentChar, mAnimal);
				currentChar = mAnimal;
				currentCharIndex = index;
				OnSwap.Invoke(mAnimal.gameObject);
				mAnimal.InputSource.MoveAxis = rawInputAxis;
			}
		}

		public void Swap()
		{
			Swap(currentCharIndex + 1);
		}

		public void Swap(MAnimal Old, MAnimal New)
		{
			StateID stateID = (New.OverrideStartState = Old.ActiveStateID);
			if ((int)stateID == StateEnum.Jump || !New.HasState(stateID))
			{
				New.OverrideStartState = Fall;
			}
			New.gameObject.SetActive(value: true);
			New.TeleportRot(Old.transform);
			New.Move_Direction = Old.Move_Direction;
			New.MovementAxisRaw = Old.MovementAxisRaw;
			New.MovementAxis = Old.MovementAxis;
			New.DeltaPos = Old.DeltaPos;
			New.DeltaRootMotion = Old.DeltaRootMotion;
			New.InertiaPositionSpeed = Old.HorizontalVelocity * New.DeltaTime;
			New.t.position = Old.t.position;
			New.SetMaxMovementSpeed();
			New.TargetSpeed = Old.TargetSpeed;
			New.Gravity = Old.Gravity;
			New.GravityTime = Old.GravityTime;
			New.HorizontalSpeed = Old.HorizontalSpeed;
			New.HorizontalVelocity = Old.HorizontalVelocity;
			Old.gameObject.SetActive(value: false);
		}

		private void Reset()
		{
			Fall = MTools.GetInstance<StateID>("Fall");
		}
	}
}
