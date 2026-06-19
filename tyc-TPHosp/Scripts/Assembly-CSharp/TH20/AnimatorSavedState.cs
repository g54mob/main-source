using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class AnimatorSavedState
	{
		private class AnimParam
		{
			private AnimatorControllerParameterType _type;

			private string _name;

			private object _data;

			public AnimParam(Animator anim, string name, AnimatorControllerParameterType type)
			{
				_type = type;
				_name = name;
				switch (type)
				{
				case AnimatorControllerParameterType.Int:
					_data = anim.GetInteger(name);
					break;
				case AnimatorControllerParameterType.Float:
					_data = anim.GetFloat(name);
					break;
				case AnimatorControllerParameterType.Bool:
					_data = anim.GetBool(name);
					break;
				case AnimatorControllerParameterType.Trigger:
					_data = anim.GetBool(name);
					break;
				}
			}

			public void Restore(Animator animator)
			{
				if (!animator.HasParameter(_name))
				{
					return;
				}
				switch (_type)
				{
				case AnimatorControllerParameterType.Int:
					animator.SetInteger(_name, (int)_data);
					break;
				case AnimatorControllerParameterType.Float:
					animator.SetFloat(_name, (float)_data);
					break;
				case AnimatorControllerParameterType.Bool:
					animator.SetBool(_name, (bool)_data);
					break;
				case AnimatorControllerParameterType.Trigger:
					if (_data != null && (bool)_data)
					{
						animator.SetTrigger(_name);
					}
					else
					{
						animator.ResetTrigger(_name);
					}
					break;
				}
			}
		}

		private struct Bone
		{
			public Transform Transform;

			public Vector3 Position;

			public Quaternion Rotation;
		}

		private readonly AnimatorStateInfo _stateInfo;

		private readonly List<AnimParam> _savedParams;

		[DontSave]
		private readonly List<Bone> _bones;

		public AnimatorSavedState(Animator animator)
		{
			if (!(animator != null))
			{
				return;
			}
			if (animator.runtimeAnimatorController != null)
			{
				_savedParams = new List<AnimParam>();
				AnimatorControllerParameter[] parameters = animator.parameters;
				foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
				{
					_savedParams.Add(new AnimParam(animator, animatorControllerParameter.name, animatorControllerParameter.type));
				}
				_stateInfo = animator.GetCurrentAnimatorStateInfo(0);
			}
			_bones = new List<Bone>();
			Transform[] componentsInChildrenOnly = animator.gameObject.GetComponentsInChildrenOnly<Transform>();
			foreach (Transform transform in componentsInChildrenOnly)
			{
				Bone item = new Bone
				{
					Transform = transform,
					Position = transform.localPosition,
					Rotation = transform.localRotation
				};
				_bones.Add(item);
			}
		}

		public void Restore(Animator animator)
		{
			if (!(animator != null))
			{
				return;
			}
			if (_savedParams != null)
			{
				foreach (AnimParam savedParam in _savedParams)
				{
					savedParam.Restore(animator);
				}
				if (animator.runtimeAnimatorController != null)
				{
					animator.Play(_stateInfo.shortNameHash, 0, _stateInfo.normalizedTime);
					animator.Update(Time.unscaledDeltaTime);
				}
			}
			if (_bones == null)
			{
				return;
			}
			foreach (Bone bone in _bones)
			{
				Transform transform = bone.Transform;
				if (transform != null)
				{
					transform.localPosition = bone.Position;
					transform.localRotation = bone.Rotation;
				}
			}
		}
	}
}
