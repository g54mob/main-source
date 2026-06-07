using System;
using System.Collections.Generic;
using Lightbug.CharacterControllerPro.Core;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	public abstract class CharacterDetector : MonoBehaviour
	{
		protected Dictionary<Transform, CharacterActor> characters = new Dictionary<Transform, CharacterActor>();

		protected List<int> onEnterDirtyTransforms = new List<int>();

		protected List<int> onStayDirtyTransforms = new List<int>();

		protected List<int> onExitDirtyTransforms = new List<int>();

		public int CharactersNumber { get; private set; }

		protected virtual void ProcessEnterAction(CharacterActor characterActor)
		{
		}

		protected virtual void ProcessStayAction(CharacterActor characterActor)
		{
		}

		protected virtual void ProcessExitAction(CharacterActor characterActor)
		{
		}

		private void FixedUpdate()
		{
			if (onEnterDirtyTransforms.Count != 0)
			{
				onEnterDirtyTransforms.Clear();
			}
			if (onStayDirtyTransforms.Count != 0)
			{
				onStayDirtyTransforms.Clear();
			}
			if (onExitDirtyTransforms.Count != 0)
			{
				onExitDirtyTransforms.Clear();
			}
		}

		private void ProcessAction(Transform transform, List<int> characterActorsIDList, Action<CharacterActor> Action)
		{
			if (!base.enabled)
			{
				return;
			}
			CharacterActor orRegisterValue = characters.GetOrRegisterValue(transform);
			if (!(orRegisterValue == null))
			{
				int instanceID = orRegisterValue.GetInstanceID();
				if (!characterActorsIDList.Contains(instanceID))
				{
					characterActorsIDList.Add(instanceID);
					CharactersNumber++;
					Action?.Invoke(orRegisterValue);
				}
			}
		}

		private void OnTriggerEnter(Collider collider)
		{
			Rigidbody attachedRigidbody = collider.attachedRigidbody;
			if (!(attachedRigidbody == null))
			{
				ProcessAction(attachedRigidbody.transform, onEnterDirtyTransforms, ProcessEnterAction);
			}
		}

		private void OnTriggerEnter2D(Collider2D collider)
		{
			Rigidbody2D attachedRigidbody = collider.attachedRigidbody;
			if (!(attachedRigidbody == null))
			{
				ProcessAction(attachedRigidbody.transform, onEnterDirtyTransforms, ProcessEnterAction);
			}
		}

		private void OnTriggerStay(Collider collider)
		{
			Rigidbody attachedRigidbody = collider.attachedRigidbody;
			if (!(attachedRigidbody == null))
			{
				ProcessAction(attachedRigidbody.transform, onStayDirtyTransforms, ProcessStayAction);
			}
		}

		private void OnTriggerStay2D(Collider2D collider)
		{
			Rigidbody2D attachedRigidbody = collider.attachedRigidbody;
			if (!(attachedRigidbody == null))
			{
				ProcessAction(attachedRigidbody.transform, onStayDirtyTransforms, ProcessStayAction);
			}
		}

		private void OnTriggerExit(Collider collider)
		{
			Rigidbody attachedRigidbody = collider.attachedRigidbody;
			if (!(attachedRigidbody == null))
			{
				ProcessAction(attachedRigidbody.transform, onExitDirtyTransforms, ProcessExitAction);
			}
		}

		private void OnTriggerExit2D(Collider2D collider)
		{
			Rigidbody2D attachedRigidbody = collider.attachedRigidbody;
			if (!(attachedRigidbody == null))
			{
				ProcessAction(attachedRigidbody.transform, onExitDirtyTransforms, ProcessExitAction);
			}
		}
	}
}
