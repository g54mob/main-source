using System.Collections.Generic;
using Brewery.Voice;
using UnityEngine;

namespace Brewery.Face
{
	public class FaceDebugOverlay : MonoBehaviour
	{
		[SerializeField]
		private FaceDriver target;

		[SerializeField]
		private bool visible;

		[SerializeField]
		private int topBlendshapeCount;

		private VivoxPlayerTracker _voice;

		private GUIStyle _label;

		private GUIStyle _header;

		private GUIStyle _btn;

		private Texture2D _bgTex;

		private Texture2D _headerTex;

		private Texture2D _btnTex;

		private Vector2 _scroll;

		private bool _testBrowUp;

		private bool _testBrowFrown;

		private bool _testCheek;

		private bool _testMouth;

		private bool _testJaw;

		private bool _testEye;

		private bool _testNose;

		private bool _testEyeLeft;

		private bool _testEyeRight;

		private bool _testEyeUp;

		private bool _testEyeDown;

		private static readonly string[] _eyeLookLeftShapes;

		private static readonly string[] _eyeLookRightShapes;

		private static readonly string[] _eyeLookUpShapes;

		private static readonly string[] _eyeLookDownShapes;

		private static readonly string[] _browUpShapes;

		private static readonly string[] _browFrownShapes;

		private static readonly string[] _cheekShapes;

		private static readonly string[] _mouthShapes;

		private static readonly string[] _jawShapes;

		private static readonly string[] _eyeShapes;

		private static readonly string[] _noseShapes;

		private static readonly string[] _facePrefixes;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void EnsureStyles()
		{
		}

		private static Texture2D MakeTex(Color c)
		{
			return null;
		}

		private void OnDestroy()
		{
		}

		private void OnGUI()
		{
		}

		private void SectionHeader(string text)
		{
		}

		private static string Y(bool b)
		{
			return null;
		}

		private static string JoinFirst(IReadOnlyList<string> list, int max)
		{
			return null;
		}

		private static bool IsFaceName(string bare)
		{
			return false;
		}

		private static string OnOff(bool b)
		{
			return null;
		}

		private void ToggleTest(string[] shapes, ref bool state)
		{
		}

		private void ClearEyeTests()
		{
		}

		private void ClearAllTests()
		{
		}
	}
}
