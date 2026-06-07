using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics.Blitters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Objects
{
	public class DamageNumberManager : MonoBehaviour
	{
		[SerializeField]
		private List<Sprite> _numberSprites;

		[SerializeField]
		private int _MaxAmount;

		[SerializeField]
		private int SpawnSpam;

		private Blitter _blitter;

		private bool _blittersMade;

		private List<float> RANDOMS;

		private List<float> RANDOMSY;

		private int INDEX;

		private List<Bob> _bobs;

		private List<BobGroup> _groups;

		private GameSessionData _session;

		private SignalBus _signalBus;

		private Bounds _bobMaxBounds;

		private Color32 _white;

		public int Count;

		public Color32 ColorMax;

		public Color32 Color010;

		public Color32 Color006;

		public Color32 Color003;

		public Color32 Color000;

		public Color32 ColorNeg;

		private ProfilerMarker updateBobMarker;

		private ProfilerMarker deleteBobsMarker;

		private static int[] digitsArray;

		[Inject]
		private void Construct(GameSessionData session, SignalBus signalBus)
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void LateUpdate()
		{
		}

		private void MakeBlitters()
		{
		}

		private void Spawn(UISignals.CreateDamageNumberSignal sig)
		{
		}

		private void AddBob(Blitter blitter, int num, float rawDamage, Vector3 worldPos, float growth = 2f)
		{
		}

		private void AddBobSpecial(UISignals.CreateSpecialDamageNumberSignal sig)
		{
		}

		public void AddBob_Number1(Vector3 worldPos)
		{
		}

		private static int[] SplitIntByDigitsReversed(int number, out int numDigits)
		{
			numDigits = default(int);
			return null;
		}

		private Color32 GetDamageColour(float rawDamage)
		{
			return default(Color32);
		}

		private int GetDamageValue(int rawDamage)
		{
			return 0;
		}
	}
}
