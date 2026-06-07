using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft.Wings.ControlSurfaces;
using Assets.Scripts.Craft.Wings.Physics;
using Assets.Scripts.Craft.Wings.Runtime;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Craft.Wings.Utilities
{
	public class TestWingGenerator : MonoBehaviour
	{
		private class FakeInput
		{
			public int SurfaceIdx { get; set; }

			public string SurfaceName { get; set; }

			public int ControlIdx { get; set; }

			public float2 Range { get; set; }

			public float Value { get; set; }
		}

		[SerializeField]
		private WingDebugInfo _debug;

		[SerializeField]
		private int _defaultColliderSamples = 8;

		[SerializeField]
		private int _defaultSamples = 15;

		[SerializeField]
		private bool _flipped;

		[SerializeField]
		private int _physicsSamples = 16;

		private WingInputManager _input;

		private List<FakeInput> _inputs;

		[SerializeField]
		private Material[] _materials;

		private WingPhysicsManager _physics;

		private Rect _winRect = new Rect(50f, 50f, 300f, 300f);

		[SerializeField]
		private TextAsset _xmlAsset;

		[ContextMenu("Debug")]
		public WingDebugInfo DebugWing()
		{
			WingDebugInfo wingDebugInfo = new WingDebugInfo();
			Generate(wingDebugInfo);
			_debug = wingDebugInfo;
			return wingDebugInfo;
		}

		[ContextMenu("Generate")]
		public void Generate()
		{
			Generate(null);
		}

		protected void OnGUI()
		{
			if (_inputs == null || _inputs.Count == 0)
			{
				return;
			}
			_winRect = GUI.Window(GetInstanceID(), _winRect, delegate
			{
				GUILayout.BeginVertical();
				if (_physics != null)
				{
					_physics.DebugEnable = GUILayout.Toggle(_physics.DebugEnable, "Physics Debug");
				}
				int num = -1;
				for (int i = 0; i < _inputs.Count; i++)
				{
					FakeInput fakeInput = _inputs[i];
					if (num != fakeInput.SurfaceIdx)
					{
						num = fakeInput.SurfaceIdx;
						GUILayout.Label(fakeInput.SurfaceName);
					}
					fakeInput.Value = GUILayout.HorizontalSlider(fakeInput.Value, fakeInput.Range.x, fakeInput.Range.y);
					GUILayout.Space(10f);
				}
				GUILayout.EndVertical();
				GUI.DragWindow();
			}, "Inputs");
		}

		protected void Start()
		{
			_inputs = new List<FakeInput>();
			WingRuntimeOutput wingRuntimeOutput = WingBuilder.Generate(GetInput(), _physicsSamples);
			_input = new WingInputManager(wingRuntimeOutput);
			Rigidbody rigidbody;
			if ((rigidbody = GetComponentInParent<Rigidbody>()) == null)
			{
				rigidbody = base.gameObject.AddComponent<Rigidbody>();
				rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			}
			_physics = new WingPhysicsManager(wingRuntimeOutput, this, _input, rigidbody);
			for (int i = 0; i < wingRuntimeOutput.ControlSurfaces.Length; i++)
			{
				IControlSurfaceRuntimeData controlSurfaceRuntimeData = _input.ControlSurfaceRuntimeData[i];
				for (int j = 0; j < controlSurfaceRuntimeData.InputCount; j++)
				{
					FakeInput fi = new FakeInput
					{
						ControlIdx = j,
						SurfaceIdx = i,
						SurfaceName = wingRuntimeOutput.ControlSurfaces[i].GetType().Name,
						Range = _input.GetInputRange(i, j)
					};
					_input.SetInputGetter(i, j, () => fi.Value);
					_inputs.Add(fi);
				}
			}
		}

		private void Generate(WingDebugInfo debug)
		{
			WingBuilderInput input = GetInput(debug);
			Stopwatch stopwatch = Stopwatch.StartNew();
			WingBuilder.Generate(input);
			stopwatch.Stop();
			UnityEngine.Debug.Log($"Generated in {stopwatch.Elapsed.TotalMilliseconds:0.00}ms");
		}

		private WingBuilderInput GetInput(WingDebugInfo debugInfo = null)
		{
			XElement root = XDocument.Parse(_xmlAsset.text).Root;
			InputWingSlice[] inputSlices = (from x in root.Elements("Slice")
				select new InputWingSlice(x, _defaultSamples, _defaultColliderSamples)).ToArray();
			ControlSurface[] surfaces = (from e in root.Elements("ControlSurface")
				select ControlSurface.TryCreateControlSurface(e)).ToArray();
			XElement xElement = root.Element("Wingtip");
			WingTipStyle wingtipStyle = ((xElement != null) ? WingTipRegistry.Resolve(xElement) : null);
			return new WingBuilderInput
			{
				inputSlices = inputSlices,
				surfaces = surfaces,
				flipped = _flipped,
				parent = base.transform,
				onCreateRenderer = delegate(MeshRenderer r, int i)
				{
					r.sharedMaterial = _materials[Math.Min(i, _materials.Length - 1)];
				},
				DebugCollector = debugInfo,
				WingtipStyle = wingtipStyle
			};
		}
	}
}
