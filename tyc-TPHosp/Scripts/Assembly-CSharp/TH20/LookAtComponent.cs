using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class LookAtComponent : EntityTickComponent
	{
		private class POI
		{
			public LookAtPOI LookAtPOI;

			public float Time;
		}

		private const float BlendSpeed = 4f;

		private const float ReactionSpeed = 5f;

		private const float YawMinLimit = -45f;

		private const float YawMaxLimit = 45f;

		private const float PitchMinLimit = -10f;

		private const float PitchMaxLimit = 10f;

		private readonly Dictionary<LookAtPOI, float> _pointsOfInterest = new Dictionary<LookAtPOI, float>();

		private List<POI> _pointsOfInterestNew = new List<POI>();

		private List<LookAtPOI> _ownedPointsOfInterest = new List<LookAtPOI>();

		private static readonly List<POI> _poiToRemoveCache = new List<POI>(64);

		private int _disableCount;

		private float _weight;

		private Quaternion _lookAt;

		private Quaternion _desiredLookAt;

		private Quaternion _finalRotation;

		private AnimatorCullingMode _animatorCullingMode;

		[DontSave]
		private Character _character;

		private string _debugCharacterName;

		public override string ToString()
		{
			return string.Format("TH20.LookAtComponent : {0}", _debugCharacterName.IsNullOrEmpty() ? "NULL" : _debugCharacterName);
		}

		protected override Type ValidEntityType()
		{
			return typeof(Character);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_character = GetOwner<Character>();
			_debugCharacterName = _character.ToString();
			_animatorCullingMode = _character.Animator.cullingMode;
			_character.Animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			if (_pointsOfInterestNew == null)
			{
				_pointsOfInterestNew = new List<POI>();
				foreach (KeyValuePair<LookAtPOI, float> item in _pointsOfInterest)
				{
					_pointsOfInterestNew.Add(new POI
					{
						LookAtPOI = item.Key,
						Time = item.Value
					});
				}
				_pointsOfInterest.Clear();
			}
			_character = GetOwner<Character>();
			_debugCharacterName = _character.ToString();
			foreach (LookAtPOI item2 in _ownedPointsOfInterest)
			{
				item2.RestoreFromSave(_character.Level.EntityManager);
			}
		}

		public override void Destroy()
		{
			if (_character != null)
			{
				if (_character.Interaction != null)
				{
					_character.Interaction.EnableLookAt();
				}
				_character.Animator.cullingMode = _animatorCullingMode;
			}
			base.Destroy();
		}

		public override void LateTick()
		{
			base.LateTick();
			RemoveDestroyedAndTimedOutPOIs();
			if (_character.Visual != null && _character.Visual.HeadSocket != null)
			{
				float deltaTime = Time.deltaTime;
				Transform transform = _character.Visual.HeadSocket.transform;
				float num = 0f;
				if (_disableCount == 0)
				{
					LookAtPOI bestPOI = ChooseBestPOI(_character, transform);
					num = UpdateDesiredLookat(bestPOI, transform, num);
				}
				if (deltaTime > 0f || num <= 0f)
				{
					_weight += (num - _weight) * Time.unscaledDeltaTime * 4f;
					_lookAt = Quaternion.Slerp(_lookAt, _desiredLookAt, deltaTime * 5f);
					_finalRotation = Quaternion.Slerp(transform.rotation, _lookAt, _weight);
				}
				transform.rotation = _finalRotation;
			}
		}

		private float UpdateDesiredLookat(LookAtPOI bestPOI, Transform headTransform, float desiredWeight)
		{
			if (bestPOI != null)
			{
				Quaternion rotation = headTransform.rotation;
				Quaternion quaternion = Quaternion.Inverse(rotation);
				Vector3 lookAt = bestPOI.GetLookAt(headTransform.position, out desiredWeight);
				Vector3 forward = quaternion * lookAt;
				if (forward.sqrMagnitude > 0.001f)
				{
					Quaternion quaternion2 = Quaternion.LookRotation(forward);
					float x = MathUtils.ClampAngle(quaternion2.eulerAngles.x, -45f, 45f);
					float y = MathUtils.ClampAngle(quaternion2.eulerAngles.y, -10f, 10f);
					quaternion2 = Quaternion.Euler(x, y, 0f);
					_desiredLookAt = rotation * quaternion2;
				}
				DebugDrawUtils.Line(headTransform.position, headTransform.position + lookAt * desiredWeight, Color.magenta);
			}
			return desiredWeight;
		}

		private LookAtPOI ChooseBestPOI(Character character, Transform headTransform)
		{
			LookAtPOI result = null;
			float num = 0f;
			Room roomUsing = character.RoomUsing;
			foreach (POI item in _pointsOfInterestNew)
			{
				LookAtPOI lookAtPOI = item.LookAtPOI;
				Room roomIn = lookAtPOI.Source.GetRoomIn();
				if (roomIn == null || roomIn == roomUsing)
				{
					float interest = lookAtPOI.GetInterest(headTransform.position);
					if (interest > num)
					{
						result = lookAtPOI;
						num = interest;
					}
				}
			}
			return result;
		}

		private void RemoveDestroyedAndTimedOutPOIs()
		{
			float time = GameTime.time;
			_poiToRemoveCache.Clear();
			foreach (POI item in _pointsOfInterestNew)
			{
				LookAtPOI lookAtPOI = item.LookAtPOI;
				float time2 = item.Time;
				if (lookAtPOI.HasBeenDestroyed() || time > time2 + lookAtPOI.Duration)
				{
					_poiToRemoveCache.Add(item);
				}
			}
			foreach (POI item2 in _poiToRemoveCache)
			{
				_pointsOfInterestNew.Remove(item2);
				_ownedPointsOfInterest.Remove(item2.LookAtPOI);
			}
			_poiToRemoveCache.Clear();
		}

		public void AddPOI(LookAtPOI POI)
		{
			foreach (POI item in _pointsOfInterestNew)
			{
				if (item.LookAtPOI == POI)
				{
					item.Time = GameTime.time;
					return;
				}
			}
			_pointsOfInterestNew.Add(new POI
			{
				LookAtPOI = POI,
				Time = GameTime.time
			});
		}

		public void AddAndOwnPOI(LookAtPOI POI)
		{
			AddPOI(POI);
			_ownedPointsOfInterest.AddUnique(POI);
		}

		public void RemovePOI(LookAtPOI POI)
		{
			foreach (POI item in _pointsOfInterestNew)
			{
				if (item.LookAtPOI == POI)
				{
					_pointsOfInterestNew.Remove(item);
					break;
				}
			}
			_ownedPointsOfInterest.Remove(POI);
		}

		public void SetEnabled(bool enabled)
		{
			if (enabled)
			{
				_disableCount--;
			}
			else
			{
				_disableCount++;
			}
		}
	}
}
