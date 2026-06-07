using System.Collections.Generic;
using MagicaCloth2;
using MyStuff.CharacterCustomizer.Sidekick;
using UnityEngine;

namespace Brewery.DynBones
{
	[DisallowMultipleComponent]
	public class DynBoneDriver : MonoBehaviour
	{
		[Header("Master")]
		[SerializeField]
		private bool enableDriver;

		[SerializeField]
		private DynBoneTuningSet tuningSet;

		[Header("Rebuild Detection")]
		[Tooltip("How often to poll for character rebuild (seconds).")]
		[SerializeField]
		private float pollInterval;

		[Tooltip("Wait this long after the LAST detected change before rebuilding cloth.")]
		[SerializeField]
		private float rebuildDebounce;

		[Header("Culling")]
		[SerializeField]
		private float maxSimulationDistance;

		[Tooltip("Hard cap of cloth components per character.")]
		[SerializeField]
		private int maxCloths;

		[Header("Child Detection")]
		[Tooltip("Name substrings to search for as the character model root (checked in order).")]
		[SerializeField]
		private string[] modelRootHints;

		[Header("Customizer Scene Hook")]
		[Tooltip("If assigned, the driver uses this controller's GetCharacterModel() to find the character directly. Avoids any scanning in the customizer scene.")]
		[SerializeField]
		private SidekickCustomizerSceneController customizerController;

		[Header("Body Colliders")]
		[SerializeField]
		private bool enableBodyColliders;

		[SerializeField]
		private float headRadius;

		[SerializeField]
		private float chestRadius;

		[SerializeField]
		private float chestLength;

		[SerializeField]
		private float shoulderRadius;

		[SerializeField]
		private float shoulderLength;

		[SerializeField]
		private float upperarmRadius;

		[SerializeField]
		private float upperarmLength;

		[Header("Debug")]
		[SerializeField]
		private bool log;

		private Transform _modelRoot;

		private int _cachedDescendantCount;

		private float _lastPoll;

		private float _modelChangedAt;

		private bool _culled;

		private readonly List<GameObject> _spawnedClothObjects;

		private readonly List<MagicaCloth> _activeCloths;

		private readonly List<GameObject> _spawnedColliderObjects;

		private readonly List<ColliderComponent> _activeColliders;

		public int ActiveClothCount => 0;

		public Transform WatchedModelRoot => null;

		private void Awake()
		{
		}

		private void LateUpdate()
		{
		}

		private void OnDestroy()
		{
		}

		private void PollForRebuild(float t)
		{
		}

		private Transform FindModelRoot()
		{
			return null;
		}

		private static int CountAllDescendants(Transform root)
		{
			return 0;
		}

		private static bool HasAnyDynBone(Transform t)
		{
			return false;
		}

		private void Rebuild()
		{
		}

		private void ScanAndInstallDynBones()
		{
		}

		private bool InstallCloth(string prefix, int index, Transform rootBone, DynBoneTuning tuning, bool asSpring)
		{
			return false;
		}

		private void InstallSkirts()
		{
		}

		private static SkinnedMeshRenderer FindSmrByNameSubstring(SkinnedMeshRenderer[] smrs, string substring)
		{
			return null;
		}

		private bool InstallSkirtCloth(string label, DynBoneTuning tuning, SkinnedMeshRenderer smr, int[] waistBones)
		{
			return false;
		}

		private static float WaistWeight(BoneWeight bw, int[] waistBones)
		{
			return 0f;
		}

		private static int FindBoneIndex(SkinnedMeshRenderer smr, string boneName)
		{
			return 0;
		}

		private static string SanitizeName(string s)
		{
			return null;
		}

		private void BuildBodyColliders()
		{
		}

		private Transform FindBone(string boneName)
		{
			return null;
		}

		private void TryAddSphere(string boneName, float radius, Vector3 center)
		{
		}

		private void TryAddCapsule(string boneName, float startRadius, float endRadius, float length, MagicaCapsuleCollider.Direction dir)
		{
		}

		private void TearDown()
		{
		}

		private void UpdateCulling()
		{
		}

		private static bool IsDynBone(string name)
		{
			return false;
		}

		private static string ExtractPrefix(string name)
		{
			return null;
		}
	}
}
