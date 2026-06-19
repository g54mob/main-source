using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class AnimalMagnetismComponent : EntityTickComponent
	{
		private enum State
		{
			AttachedToPlayer = 0,
			Cured = 1
		}

		private struct BoneEntry
		{
			public Transform Bone;

			public PlacementDescription PlacementDescription;
		}

		private struct AnimalMesh
		{
			public GameObject Mesh;

			public Vector3 OffsetPosition;

			public Vector3 OffsetRotation;
		}

		private struct PlacementDescription
		{
			public string BoneName;

			[InspectorMargin(8)]
			[InspectorHeader("Pivot")]
			public Vector3 LocalPositionPivot;

			public Vector3 LocalRotationPivot;

			public Vector3 MinPivotRotation;

			public Vector3 MaxPivotRotation;

			[InspectorMargin(8)]
			[InspectorHeader("Animal")]
			public float CurrentTwitchTime;

			public Vector3 AnimalLocalPosition;

			public Vector3 AnimalLocalRotation;

			public Vector3 MinAnimalRotation;

			public Vector3 MaxAnimalRotation;
		}

		private struct AnimalInstance
		{
			public Transform PivotTransform;

			public Transform AnimalTransform;

			public Quaternion InitialLocalRotation;

			public float TwitchTime;

			public float TwitchDuration;

			public Quaternion LastTwitchRotation;

			public Quaternion NextTwitchRotation;

			public AnimalMagnetismCureAnim CureAnim;
		}

		[Serializable]
		private class Config
		{
			public int _numOfAnimals = 5;

			public float _twitchDurationMin = 0.2f;

			public float _twitchDurationMax = 0.7f;

			public float _twitchRotation = 0.1f;

			public AnimalMagnetismCureAnim.Config _cureAnimConfig;

			public AnimalMesh[] _animalMeshes;

			public Material[] _animalMaterials;

			public PlacementDescription[] _animalPlacements;

			public int _numOfCureBlasts = 4;
		}

		[SerializeField]
		private Config _config;

		private UnityEngine.Random.State _randomState;

		private int _remainingCureBlasts;

		private int[] _numOfAnimalsForEachBlast;

		[DontSave]
		private AnimalInstance[] _animalInstances;

		[DontSave]
		private Patient _patient;

		[DontSave]
		private bool _animalsCulled;

		private State _currentState;

		private RoomItem _currentCureMachine;

		protected override Type ValidEntityType()
		{
			return typeof(Patient);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_randomState = UnityEngine.Random.state;
			_patient = GetOwner<Patient>();
			_animalsCulled = false;
			CreateAnimals();
			_remainingCureBlasts = _config._numOfCureBlasts;
			RegisterAnimationEvents(_patient);
		}

		private void CreateAnimals()
		{
			Transform[] rigBones = _patient.Visual.RigBones;
			List<BoneEntry> list = new List<BoneEntry>(32);
			for (int i = 0; i < _config._animalPlacements.Length; i++)
			{
				for (int j = 0; j < rigBones.Length; j++)
				{
					if (rigBones[j].name == _config._animalPlacements[i].BoneName)
					{
						list.Add(new BoneEntry
						{
							Bone = rigBones[j],
							PlacementDescription = _config._animalPlacements[i]
						});
						break;
					}
				}
			}
			_animalInstances = new AnimalInstance[_config._numOfAnimals];
			for (int k = 0; k < _config._numOfAnimals; k++)
			{
				if (list.Count == 0)
				{
					break;
				}
				int index = UnityEngine.Random.Range(0, list.Count);
				PlaceAnimal(list[index], out var pivotTransform, out var animalOffsetTransform);
				_animalInstances[k].PivotTransform = pivotTransform;
				_animalInstances[k].AnimalTransform = animalOffsetTransform;
				_animalInstances[k].InitialLocalRotation = pivotTransform.localRotation;
				_animalInstances[k].NextTwitchRotation = pivotTransform.localRotation;
				CalculateNextTwitchPosition(ref _animalInstances[k]);
				list.RemoveAt(index);
			}
		}

		private void PlaceAnimal(BoneEntry boneEntry, out Transform pivotTransform, out Transform animalOffsetTransform)
		{
			AnimalMesh animalMesh = _config._animalMeshes[UnityEngine.Random.Range(0, _config._animalMeshes.Length)];
			GameObject gameObject = new GameObject("Animal Pivot");
			GameObject gameObject2 = new GameObject("Animal Offset");
			GameObject gameObject3 = UnityEngine.Object.Instantiate(animalMesh.Mesh, gameObject2.transform, worldPositionStays: false);
			pivotTransform = gameObject.transform;
			animalOffsetTransform = gameObject2.transform;
			animalOffsetTransform.SetParent(gameObject.transform, worldPositionStays: false);
			pivotTransform.SetParent(boneEntry.Bone, worldPositionStays: false);
			gameObject3.transform.localPosition = animalMesh.OffsetPosition;
			gameObject3.transform.localRotation = Quaternion.Euler(animalMesh.OffsetRotation);
			Vector3 minAnimalRotation = boneEntry.PlacementDescription.MinAnimalRotation;
			Vector3 maxAnimalRotation = boneEntry.PlacementDescription.MaxAnimalRotation;
			Vector3 vector = new Vector3(UnityEngine.Random.Range(minAnimalRotation.x, maxAnimalRotation.x), UnityEngine.Random.Range(minAnimalRotation.y, maxAnimalRotation.y), UnityEngine.Random.Range(minAnimalRotation.z, maxAnimalRotation.z));
			float num = UnityEngine.Random.Range(0.75f, 1f);
			animalOffsetTransform.localPosition = boneEntry.PlacementDescription.AnimalLocalPosition;
			animalOffsetTransform.localRotation = Quaternion.Euler(boneEntry.PlacementDescription.AnimalLocalRotation + vector);
			animalOffsetTransform.localScale = new Vector3(num, num, num);
			Vector3 minPivotRotation = boneEntry.PlacementDescription.MinPivotRotation;
			Vector3 maxPivotRotation = boneEntry.PlacementDescription.MaxPivotRotation;
			Vector3 vector2 = new Vector3(UnityEngine.Random.Range(minPivotRotation.x, maxPivotRotation.x), UnityEngine.Random.Range(minPivotRotation.y, maxPivotRotation.y), UnityEngine.Random.Range(minPivotRotation.z, maxPivotRotation.z));
			pivotTransform.localPosition = boneEntry.PlacementDescription.LocalPositionPivot;
			pivotTransform.localRotation = Quaternion.Euler(boneEntry.PlacementDescription.LocalRotationPivot + vector2);
			gameObject3.GetComponentInChildren<MeshRenderer>().sharedMaterial = _config._animalMaterials.RandomItem();
		}

		private void DestroyAnimalInstance(ref AnimalInstance animalInstance)
		{
			animalInstance.CureAnim = default(AnimalMagnetismCureAnim);
			if (animalInstance.PivotTransform != null)
			{
				UnityEngine.Object.Destroy(animalInstance.PivotTransform.gameObject);
				animalInstance.PivotTransform = null;
			}
			if (animalInstance.AnimalTransform != null)
			{
				UnityEngine.Object.Destroy(animalInstance.AnimalTransform.gameObject);
				animalInstance.AnimalTransform = null;
			}
		}

		internal override void RestoreComponentFromSave()
		{
			_patient = GetOwner<Patient>();
			_animalsCulled = false;
			RegisterAnimationEvents(_patient);
			if (_remainingCureBlasts <= 0)
			{
				return;
			}
			if (_currentState == State.AttachedToPlayer)
			{
				UnityEngine.Random.state = _randomState;
				CreateAnimals();
			}
			UnityEngine.Random.InitState(Time.frameCount);
			if (_numOfAnimalsForEachBlast != null)
			{
				int num = 0;
				for (int i = 0; i < _config._numOfCureBlasts - _remainingCureBlasts; i++)
				{
					num += _numOfAnimalsForEachBlast[i];
				}
				for (int j = 0; j < num; j++)
				{
					DestroyAnimalInstance(ref _animalInstances[j]);
				}
			}
		}

		private void RegisterAnimationEvents(Patient patient)
		{
			patient.AnimationEventListener.RegisterEvent("AnimalMagnetismCureBlast", AnimalMagnetismCureBlast);
		}

		public override void Destroy()
		{
			GetOwner<Patient>().AnimationEventListener.UnregisterEvent("AnimalMagnetismCureBlast", AnimalMagnetismCureBlast);
			if (_animalInstances != null)
			{
				for (int i = 0; i < _animalInstances.Length; i++)
				{
					DestroyAnimalInstance(ref _animalInstances[i]);
				}
			}
			base.Destroy();
		}

		private void AnimalMagnetismCureBlast(AnimationEvent animationEvent)
		{
			if (_currentState == State.Cured)
			{
				return;
			}
			if (_numOfAnimalsForEachBlast == null)
			{
				_numOfAnimalsForEachBlast = new int[_config._numOfCureBlasts];
				int num = _config._numOfAnimals;
				for (int i = 0; i < _numOfAnimalsForEachBlast.Length; i++)
				{
					if (num > 0)
					{
						_numOfAnimalsForEachBlast[i]++;
						num--;
					}
				}
				while (num > 0)
				{
					_numOfAnimalsForEachBlast[UnityEngine.Random.Range(0, _numOfAnimalsForEachBlast.Length - 1)]++;
					num--;
				}
			}
			if (_currentCureMachine == null)
			{
				Patient owner = GetOwner<Patient>();
				Room roomAtWorldCoord = base.Level.WorldState.GetRoomAtWorldCoord(owner.Position, includeHospital: false, includeClosedPlots: false);
				if (roomAtWorldCoord != null)
				{
					_currentCureMachine = roomAtWorldCoord.GetFirstItemOfType(RoomItemDefinition.Type.Machine);
				}
			}
			int num2 = _numOfAnimalsForEachBlast.Length - _remainingCureBlasts;
			if (num2 < 0 || num2 >= _numOfAnimalsForEachBlast.Length)
			{
				return;
			}
			int num3 = _numOfAnimalsForEachBlast[num2];
			if (_animalInstances != null && _currentCureMachine != null && _currentCureMachine.Visual != null && _currentCureMachine.Visual.GameObject != null)
			{
				for (int j = 0; j < _animalInstances.Length; j++)
				{
					if (num3 <= 0)
					{
						break;
					}
					if (!(_animalInstances[j].AnimalTransform == null) && _animalInstances[j].CureAnim.CurrentState == AnimalMagnetismCureAnim.State.Null)
					{
						_animalInstances[j].AnimalTransform.SetParent(_currentCureMachine.Visual.GameObject.transform, worldPositionStays: true);
						_animalInstances[j].CureAnim = new AnimalMagnetismCureAnim(_animalInstances[j].AnimalTransform, _currentCureMachine.Visual.GameObject.transform, _config._cureAnimConfig);
						num3--;
					}
				}
			}
			_remainingCureBlasts--;
		}

		private void CalculateNextTwitchPosition(ref AnimalInstance animalInstance)
		{
			animalInstance.TwitchDuration = UnityEngine.Random.Range(_config._twitchDurationMin, _config._twitchDurationMax);
			Quaternion nextTwitchRotation = Quaternion.AngleAxis(UnityEngine.Random.Range((0f - _config._twitchRotation) * 0.5f, _config._twitchRotation * 0.5f), UnityEngine.Random.onUnitSphere) * animalInstance.InitialLocalRotation;
			animalInstance.LastTwitchRotation = animalInstance.NextTwitchRotation;
			animalInstance.NextTwitchRotation = nextTwitchRotation;
		}

		public override void Tick()
		{
			if (_animalInstances != null)
			{
				bool flag = false;
				if (_patient == null || _patient.Visual == null || _patient.Visual.HiddenModeEnable || _patient.Visual.FadingModeEnable)
				{
					flag = true;
				}
				if (flag != _animalsCulled)
				{
					_animalsCulled = flag;
					for (int i = 0; i < _animalInstances.Length; i++)
					{
						if (!(_animalInstances[i].AnimalTransform == null))
						{
							_animalInstances[i].AnimalTransform.gameObject.SetActive(!_animalsCulled);
						}
					}
				}
				for (int j = 0; j < _animalInstances.Length; j++)
				{
					if (_animalInstances[j].AnimalTransform == null)
					{
						continue;
					}
					if (_animalInstances[j].CureAnim.CurrentState == AnimalMagnetismCureAnim.State.Null)
					{
						float twitchDuration = _animalInstances[j].TwitchDuration;
						float t = EasingsUtils.ExponentialEaseOut(_animalInstances[j].TwitchTime / twitchDuration);
						_animalInstances[j].PivotTransform.localRotation = Quaternion.Lerp(_animalInstances[j].LastTwitchRotation, _animalInstances[j].NextTwitchRotation, t);
						_animalInstances[j].TwitchTime += Time.deltaTime;
						if (_animalInstances[j].TwitchTime > twitchDuration)
						{
							_animalInstances[j].TwitchTime = 0f;
							CalculateNextTwitchPosition(ref _animalInstances[j]);
						}
					}
					else
					{
						_animalInstances[j].CureAnim.Update();
						if (_animalInstances[j].CureAnim.CurrentState == AnimalMagnetismCureAnim.State.End)
						{
							DestroyAnimalInstance(ref _animalInstances[j]);
						}
					}
				}
			}
			if (_animalInstances == null || _animalInstances.TrueForAll((AnimalInstance instance) => instance.AnimalTransform == null))
			{
				Destroy();
			}
		}
	}
}
