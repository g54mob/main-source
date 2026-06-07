using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Player")]
	public abstract class TUnitPlayer : TUnit, IUnitPlayer, IUnitCommon
	{
		protected const int LAYER_UI = 32;

		[SerializeField]
		protected bool m_IsControllable;

		protected Transform Camera
		{
			get
			{
				if (!(ShortcutMainCamera.Instance != null))
				{
					return null;
				}
				return ShortcutMainCamera.Instance.Get<Transform>();
			}
		}

		public bool IsControllable
		{
			get
			{
				return m_IsControllable;
			}
			set
			{
				m_IsControllable = value;
			}
		}

		public Vector3 LocalInputDirection
		{
			get
			{
				if (!(Camera != null))
				{
					return Vector3.zero;
				}
				return Camera.InverseTransformDirection(InputDirection);
			}
		}

		public Vector3 InputDirection { get; protected set; } = Vector3.zero;

		protected TUnitPlayer()
		{
			m_IsControllable = true;
		}

		public virtual void OnStartup(Character character)
		{
			base.Character = character;
		}

		public virtual void AfterStartup(Character character)
		{
			base.Character = character;
		}

		public virtual void OnDispose(Character character)
		{
			base.Character = character;
		}

		public virtual void OnEnable()
		{
		}

		public virtual void OnDisable()
		{
		}

		public virtual void OnUpdate()
		{
		}

		public virtual void OnFixedUpdate()
		{
		}

		public virtual void OnDrawGizmos(Character character)
		{
		}
	}
}
