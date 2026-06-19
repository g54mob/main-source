using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class BlendAnimationControllerComponent : EntityTickComponent
	{
		private struct RigNode
		{
			public Transform transform;

			public bool worldSpace;

			public Vector3 storedPosition;

			public Quaternion storedRotation;
		}

		private float _blendTime;

		private float _blendStartTime;

		[DontSave]
		private RigNode _rootNode;

		[DontSave]
		private RigNode[] _pose;

		[DontSave]
		private Character _character;

		protected override Type ValidEntityType()
		{
			return typeof(Character);
		}

		public override void Destroy()
		{
			if (_rootNode.transform != null)
			{
				_rootNode.transform.localPosition = Vector3.zero;
			}
			base.Destroy();
		}

		public void Init(float blendTime)
		{
			if (!(_blendTime > 0f))
			{
				_blendTime = blendTime;
				_blendStartTime = GameTime.time;
				SetupPose();
			}
		}

		private void SetupPose()
		{
			_character = GetOwner<Character>();
			GameObject rigGameObject = _character.Visual.RigGameObject;
			Transform transform = _character.GameObject.transform;
			Transform leftSocket = _character.Visual.LeftSocket;
			Transform rightSocket = _character.Visual.RightSocket;
			Transform[] rigBones = _character.Visual.RigBones;
			_pose = new RigNode[Mathf.Max(0, rigBones.Length - 1)];
			_rootNode = new RigNode
			{
				transform = rigGameObject.transform,
				storedPosition = transform.position,
				storedRotation = transform.rotation
			};
			int num = 0;
			for (int i = 0; i < rigBones.Length; i++)
			{
				if (!(rigBones[i] == _rootNode.transform))
				{
					bool worldSpace = rigBones[i] == leftSocket || rigBones[i] == rightSocket;
					_pose[num] = new RigNode
					{
						transform = rigBones[i],
						worldSpace = worldSpace,
						storedPosition = rigBones[i].localPosition,
						storedRotation = rigBones[i].localRotation
					};
					num++;
				}
			}
		}

		public override void LateTick()
		{
			float num = Mathf.Min((GameTime.time - _blendStartTime) / _blendTime, 1f);
			if (num < 1f)
			{
				for (int i = 0; i < _pose.Length; i++)
				{
					if (_pose[i].worldSpace)
					{
						Transform transform = _pose[i].transform;
						if (transform != null)
						{
							_pose[i].storedPosition = transform.position;
							_pose[i].storedRotation = transform.rotation;
						}
					}
				}
				for (int j = 0; j < _pose.Length; j++)
				{
					if (!_pose[j].worldSpace)
					{
						Transform transform2 = _pose[j].transform;
						if (transform2 != null)
						{
							transform2.localPosition = Vector3.Lerp(_pose[j].storedPosition, transform2.localPosition, num);
							transform2.localRotation = Quaternion.Slerp(_pose[j].storedRotation, transform2.localRotation, num);
						}
					}
				}
				if (_character == null)
				{
					_character = GetOwner<Character>();
				}
				Transform transform3 = _character.GameObject.transform;
				Vector3 vector = _rootNode.storedPosition - transform3.position;
				vector = Quaternion.Inverse(transform3.rotation) * vector;
				_rootNode.transform.localPosition = Vector3.Lerp(vector, Vector3.zero, num);
				for (int k = 0; k < _pose.Length; k++)
				{
					if (_pose[k].worldSpace)
					{
						Transform transform4 = _pose[k].transform;
						if (transform4 != null)
						{
							transform4.position = _pose[k].storedPosition;
							transform4.rotation = _pose[k].storedRotation;
						}
					}
				}
			}
			else
			{
				Destroy();
			}
		}
	}
}
