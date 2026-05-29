using System.Diagnostics;
using Factory.FieldData;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Serialization;

namespace Factory.FieldObject
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class Luggage : MonoBehaviour, ITemporaryBillboardCamera, IEventSystemHandler
	{
		private static bool _sceneFocusCache;

		private static int _lastCacheFrame;

		[FormerlySerializedAs("LuggageMaster")]
		public MstLuggageDataEntities luggageData;

		public MstUnitDataEntities unitData;

		public GameObject efUnitBufRed;

		public GameObject efUnitBufGreen;

		public GameObject efUnitBufBlue;

		public GameObject efUnitBufYellow;

		public GameObject efUnitBufGray;

		public SpriteRenderer colorEnchant;

		[FormerlySerializedAs("colorEnchants")]
		public Sprite[] colorEnchantsA;

		public Sprite[] colorEnchantsB;

		public Sprite[] colorEnchantsC;

		public Material normalMaterial;

		public Material monoMaterial;

		private SpriteRenderer sprRenderer;

		private Quaternion persRotation;

		private Vector3 pseudoPosition;

		private Vector3 pseudoLocalPosition;

		private LuggageSettings luggageSettings;

		private LuggageFlag flag;

		private int _preSkillLevel;

		private GameObject effectUnitBuff;

		private int coatingLevel;

		private eLuggage coatingColor;

		private Transform parentCache;

		private float scaleCache;

		private bool nowSpriteMaterial;

		[SerializeField]
		private LuggageObjectCtrl luggageObjectCtrl;

		private string _objectNameForDebug;

		public eLuggage LuggageId => default(eLuggage);

		public bool Visible
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsUnit => false;

		public bool IsParts => false;

		public bool IsMiracle => false;

		public bool IsShape => false;

		public bool IsHuman => false;

		public bool IsFairy => false;

		public bool IsDownsizing { get; set; }

		public void BringToFrontTemporarilyLayer()
		{
		}

		public void RestoreOriginalLayer()
		{
		}

		private static bool IsFocusSceneCached()
		{
			return false;
		}

		private void Awake()
		{
		}

		public void OnTakeFromPoolLikeAwake()
		{
		}

		private void Update()
		{
		}

		private void InitComponent(eLuggage product)
		{
		}

		private void ChangeSprite()
		{
		}

		private void ChangeSpriteMaterial(bool mono)
		{
		}

		public void SetPosition(Vector3 pos)
		{
		}

		public void SetLocalPosition(double x, double y, double nativeRate, double carHornLevel, bool isPushBacked)
		{
		}

		private void UpdatePosition()
		{
		}

		private void UpdateEffect()
		{
		}

		[Conditional("LUGGAGE_DEEP_LOG")]
		public void RecordDeepLog(ILuggageCarrier on, double luggageRate, double luggageSpeed)
		{
		}

		public void OnReturnedToPool()
		{
		}

		private void OnDestroy()
		{
		}

		public void OnDestroyPoolObject()
		{
		}

		private void SpriteLoaded(AsyncOperationHandle<Sprite> obj)
		{
		}

		private string GetSpritePath()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public string ToEffectDebug()
		{
			return null;
		}

		public void OnChangeCamera(Camera cm)
		{
		}

		public string ToDump()
		{
			return null;
		}

		public static Luggage Create(GameObject prefab, Vector3 pos, eLuggage product, string name, LuggageFlag luggageFlag)
		{
			return null;
		}

		public void InitObject(Vector3 pos, eLuggage product, string objectNameForDebug, LuggageFlag luggageFlag)
		{
		}

		public void SetFlag(LuggageFlag f)
		{
		}

		public void UnsetFlag(LuggageFlag f)
		{
		}

		public bool IsFlag(LuggageFlag f)
		{
			return false;
		}

		public bool HasFlag(LuggageFlag f)
		{
			return false;
		}

		public int GetFlagForSerialize()
		{
			return 0;
		}

		public void SetCoating(eLuggage ink, int level)
		{
		}

		public int GetCoatingLevel()
		{
			return 0;
		}

		public (int, string) GetCoatingForSerialize()
		{
			return default((int, string));
		}

		public float GetScale()
		{
			return 0f;
		}

		private void SetScale(float scale)
		{
		}

		public void SetScale<T>(float scale, in T carrierForDebug) where T : ILuggageCarrier
		{
		}

		public void ResetScale<T>(in T carrierForDebug) where T : ILuggageCarrier
		{
		}

		public LuggageObjectCtrl GetLuggageObjectCtrl()
		{
			return null;
		}
	}
}
