using System;
using System.Reflection;
using Assets.Scripts.Design;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Jundroo.Common.Platform;
using Jundroo.Common.Utils;
using TMPro;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class LabelScript : PartModifierScript
	{
		private static class Profile
		{
			public static readonly ProfilerMarker WakeUpLabel = new ProfilerMarker("LabelScript -> Wake Up Label");
		}

		private static class TextMeshProReflection
		{
			public static readonly FieldInfo CurrentMaterialField = typeof(TMP_Text).GetField("m_currentMaterial", BindingFlags.Instance | BindingFlags.NonPublic);

			public static readonly FieldInfo FontMaterialField = typeof(TMP_Text).GetField("m_fontMaterial", BindingFlags.Instance | BindingFlags.NonPublic);

			public static readonly FieldInfo SharedMaterialField = typeof(TMP_Text).GetField("m_sharedMaterial", BindingFlags.Instance | BindingFlags.NonPublic);

			public static readonly FieldInfo SubmeshMaterialField = typeof(TMP_SubMesh).GetField("m_material", BindingFlags.Instance | BindingFlags.NonPublic);

			public static readonly FieldInfo SubmeshSharedMaterialField = typeof(TMP_SubMesh).GetField("m_sharedMaterial", BindingFlags.Instance | BindingFlags.NonPublic);

			public static readonly FieldInfo SubmeshTextObjectsField = typeof(TextMeshPro).GetField("m_subTextObjects", BindingFlags.Instance | BindingFlags.NonPublic);
		}

		private const int DefaultRenderQueue = 3000;

		private Collider _collider;

		private DynamicExpressionText _dynamicText;

		private WireframeCubeScript _frame;

		private bool _highlighted;

		private bool _inDesigner;

		private Material _material;

		private bool _selected;

		private Tweener _tween;

		public LabelData Data { get; set; }

		public TextMeshPro Label { get; private set; }

		static LabelScript()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Add(OnTMProMeshRebuilt);
		}

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			if (this != null)
			{
				plan.Register(this, OnPreStart);
			}
		}

		public void Initialize(LabelData data)
		{
			Data = data;
			Label = GetComponent<TextMeshPro>();
			base.PartScript.PartMaterialScript.AddNonPartMaterialDataScriptRenderer(Label.GetComponent<MeshRenderer>());
			_collider = Utilities.FindFirstGameObjectMyselfOrChildren("LabelCollider", base.PartScript.gameObject)?.GetComponent<Collider>();
			OnCurvatureChanged();
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				Transform transform = Utilities.FindFirstGameObjectMyselfOrChildren("Frame", base.PartScript.gameObject)?.transform;
				if (transform != null)
				{
					_frame = transform.gameObject.AddComponent<WireframeCubeScript>();
					_frame.LineWidth = 2.5f;
					_frame.ToggleFaceVisibility(zPlus: false, zMinus: true, connectingEdges: false);
					_frame.IsVisible = false;
				}
			}
			else
			{
				_collider?.gameObject?.SetActive(value: false);
				if (string.IsNullOrWhiteSpace(Data.DesignText))
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
		}

		public void OnApplyMaterials()
		{
			_ = base.PartScript.Part.MaterialIds;
			LabelPartGradientType gradient = Data.Gradient;
			Label.outlineColor = GetPaintColor((!Data.SupportsGradient) ? 1 : 2);
			if (gradient == LabelPartGradientType.None || !Data.SupportsGradient)
			{
				Label.enableVertexGradient = false;
				Label.color = GetPaintColor(0);
			}
			else
			{
				Label.color = Color.white;
				Label.enableVertexGradient = true;
				Color paintColor = GetPaintColor(0);
				Color paintColor2 = GetPaintColor(1);
				VertexGradient colorGradient = new VertexGradient(paintColor, paintColor, paintColor, paintColor);
				switch (gradient)
				{
				case LabelPartGradientType.Vertical:
					colorGradient.bottomLeft = paintColor2;
					colorGradient.bottomRight = paintColor2;
					break;
				case LabelPartGradientType.Horizontal:
					colorGradient.topRight = paintColor2;
					colorGradient.bottomRight = paintColor2;
					break;
				case LabelPartGradientType.Diagonal:
					colorGradient.topLeft = paintColor2;
					colorGradient.bottomRight = paintColor2;
					break;
				case LabelPartGradientType.UpperLeft:
					colorGradient.topLeft = paintColor2;
					break;
				case LabelPartGradientType.UpperRight:
					colorGradient.topRight = paintColor2;
					break;
				case LabelPartGradientType.LowerLeft:
					colorGradient.bottomLeft = paintColor2;
					break;
				case LabelPartGradientType.LowerRight:
					colorGradient.bottomRight = paintColor2;
					break;
				default:
					throw new NotSupportedException($"Gradient type '{gradient}' not supported.");
				}
				Label.colorGradient = colorGradient;
			}
			UpdateEmission(Data.EmissionDay, Data.EmissionNight);
			if (Data.RenderQueueOffset != 0)
			{
				Label.renderer.material.renderQueue = 3000 + Data.RenderQueueOffset;
			}
			Label.SetVerticesDirty();
		}

		public void OnCurvatureChanged()
		{
			Label.SetVerticesDirty();
			Label.ForceMeshUpdate();
		}

		public void OnFontChanged()
		{
			switch (Data.FontName)
			{
			case "Default":
			case "Liberation Sans":
				Label.font = Resources.Load<TMP_FontAsset>("Fonts/Parts/LiberationSans/LiberationSans SDF (Surface)");
				break;
			case "Roboto":
				Label.font = Resources.Load<TMP_FontAsset>("Fonts/Parts/Roboto/PartMaterial-Roboto-Regular SDF");
				break;
			case "Military":
				Label.font = Resources.Load<TMP_FontAsset>("Fonts/Parts/PS_Jefferies/Jefferies SDF");
				break;
			case "14-Segment":
				Label.font = Resources.Load<TMP_FontAsset>("Fonts/Parts/DSEG-14-Classic/DSEG14Classic-Regular SDF");
				break;
			case "Stencil":
				Label.font = Resources.Load<TMP_FontAsset>("Fonts/Parts/AngkatanBersenjata/AngkatanBersenjata-2OD4o SDF");
				break;
			default:
				throw new NotSupportedException("Font '" + Data.FontName + "' not supported");
			}
			DestroyFontMaterials();
			_material = CreateAndAssignMaterialInstance();
			if (Data.OutlineWidth > 0f)
			{
				UpdateOutlineWidth(0f);
				UpdateOutlineWidth(Data.OutlineWidth);
			}
			Label.outlineColor = GetPaintColor((!Data.SupportsGradient) ? 1 : 2) / 2f;
			OnApplyMaterials();
		}

		public void UpdateAlignment(TextAlignmentOptions textAlignmentOptions)
		{
			Label.alignment = textAlignmentOptions;
		}

		public void UpdateEmission(float emissionDay, float emissionNight)
		{
			Material[] fontMaterials = Label.fontMaterials;
			foreach (Material obj in fontMaterials)
			{
				obj.SetFloat("_EmissiveOverride", emissionDay);
				obj.SetFloat("_EmissiveOverrideNight", emissionNight);
			}
		}

		public void UpdateFontSize(float newVal)
		{
			Label.fontSize = newVal;
			UpdateSize(Data.Width, Data.Height);
		}

		public void UpdateOutlineWidth(float outlineWidth)
		{
			Label.outlineWidth = outlineWidth;
		}

		public void UpdateSize(float width, float height)
		{
			Label.rectTransform.sizeDelta = new Vector2(width * Data.FontSize, height * Data.FontSize);
			UpdateTextCollider();
			Label.text = string.Empty;
			Label.ForceMeshUpdate();
			UpdateText(Data.DesignText);
		}

		public void UpdateText(string value)
		{
			if (Label != null && _dynamicText.ParseText(value, _inDesigner))
			{
				Label.SetText(_dynamicText.Text);
				Label.enabled = _dynamicText.Text.Length != 0;
			}
		}

		protected virtual void OnDestroy()
		{
			base.PartScript.PartMaterialScript.CustomMaterialUpdateCallback -= PartMaterialScriptUpdate;
			DestroyFontMaterials();
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			DynamicExpressionText dynamicText = _dynamicText;
			if (dynamicText != null && dynamicText.HasDynamicInput)
			{
				registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightLocal);
				registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightLocal);
			}
		}

		private static void CurveMesh(Mesh mesh, LabelData label)
		{
			Vector3[] vertices = mesh.vertices;
			Vector3[] normals = mesh.normals;
			bool flag = label.CurvatureDirection == LabelCurvatureDirection.Horizontal;
			float num = (flag ? label.Width : label.Height);
			float num2 = num / 2f;
			float num3 = label.CurvatureAngle / 2f;
			float num4 = num / (num3 * 2f / 360f) / (MathF.PI * 2f);
			Vector3 vector = Vector3.forward * num4;
			float num5 = 1f / num2 * num3 * (MathF.PI / 180f);
			for (int i = 0; i < vertices.Length; i++)
			{
				Vector3 vector2 = vertices[i];
				float f = (flag ? vector2.x : vector2.y) * num5;
				float num6 = Mathf.Sin(f) * num4;
				float num7 = Mathf.Cos(f) * num4;
				Vector3 vector3 = (vertices[i] = new Vector3(flag ? (vector.x + num6) : vector2.x, flag ? vector2.y : (vector.y + num6), vector.z - num7));
				normals[i] = (new Vector3(flag ? vector3.x : vector.x, flag ? vector.y : vector3.y, vector3.z) - vector).normalized;
			}
			mesh.vertices = vertices;
			mesh.normals = normals;
		}

		private static void OnTMProMeshRebuilt(UnityEngine.Object obj)
		{
			TextMeshPro textMeshPro = obj as TextMeshPro;
			LabelScript labelScript = textMeshPro?.GetComponent<LabelScript>();
			if (!(labelScript == null) && labelScript.Data.CurvatureAngle != 0f)
			{
				CurveMesh(textMeshPro.mesh, labelScript.Data);
				TMP_SubMesh[] componentsInChildren = textMeshPro.GetComponentsInChildren<TMP_SubMesh>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					CurveMesh(componentsInChildren[i].mesh, labelScript.Data);
				}
			}
		}

		private Material CreateAndAssignMaterialInstance()
		{
			Material fontSharedMaterial = Label.fontSharedMaterial;
			Label.renderer.sharedMaterial = fontSharedMaterial;
			Material material = Label.renderer.material;
			if (Device.IsUnityEditor)
			{
				material.name += "*";
			}
			TextMeshProReflection.SharedMaterialField.SetValue(Label, fontSharedMaterial);
			TextMeshProReflection.CurrentMaterialField.SetValue(Label, material);
			TextMeshProReflection.FontMaterialField.SetValue(Label, material);
			return material;
		}

		private void DestroyFontMaterials()
		{
			if (_material != null)
			{
				UnityEngine.Object.Destroy(_material);
				_material = null;
			}
		}

		private Color GetPaintColor(int index)
		{
			index += Data.PaintIndexShift;
			if (index >= base.PartScript.Part.MaterialIds.Count || index < 0)
			{
				Debug.LogWarning($"Label does not have material index {index}");
			}
			return base.PartScript.Aircraft.Theme.Theme.GetMaterial(base.PartScript.Part.MaterialIds[index]).PrimaryColor;
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			_dynamicText.Update();
		}

		private void OnHighlightedChanged(object sender, PartMaterialScript.PartMaterialEventArgs e)
		{
			UpdateFrameVisuals();
		}

		private void OnPaintedInDesigner(object sender, PartMaterialScript.PaintedEventArgs e)
		{
			OnApplyMaterials();
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_inDesigner = loadContext == CraftLoadContext.Designer;
			if (!base.gameObject.activeInHierarchy)
			{
				using (Profile.WakeUpLabel.Auto())
				{
					Transform parent = base.transform.parent;
					base.transform.SetParent(null, worldPositionStays: false);
					base.transform.SetParent(parent, worldPositionStays: false);
				}
			}
			_dynamicText = new DynamicExpressionText(new DynamicExpressionSource(base.PartScript.ExpressionContext));
			_dynamicText.WarningLogSource = $"label, part {base.PartScript.Part.Id}";
			_dynamicText.MatchInputs(Data.DesignText);
			if (TryGetComponent<PartRendererScript>(out var component))
			{
				component.Materials[0].MaterialLevel += Data.PaintIndexShift;
			}
			OnFontChanged();
			UpdateFontSize(Data.FontSize);
			UpdateAlignment((TextAlignmentOptions)((int)Data.HorizontalAlignment + (int)Data.VerticalAlignment));
			UpdateOutlineWidth(Data.OutlineWidth);
			OnApplyMaterials();
			if (base.PartScript.Part.PartType.PartTypeId.StartsWith("Label", StringComparison.Ordinal))
			{
				base.PartScript.PartMaterialScript.CustomMaterialUpdateCallback += PartMaterialScriptUpdate;
			}
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				base.PartScript.PartMaterialScript.OnPaintedInDesigner += OnPaintedInDesigner;
				base.PartScript.PartMaterialScript.SelectedChanged += OnSelectedChanged;
				base.PartScript.PartMaterialScript.HighlightedChanged += OnHighlightedChanged;
				UpdateFrameVisuals();
			}
			return UniTask.CompletedTask;
		}

		private void OnSelectedChanged(object sender, PartMaterialScript.PartMaterialEventArgs e)
		{
			UpdateFrameVisuals();
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			UpdateText(Data.DesignText);
		}

		private void PartMaterialScriptUpdate(object sender, PartMaterialScript.MaterialUpdateEventArgs args)
		{
			if (args.Color.HasValue)
			{
				SetPrimaryColor(args.Color.Value);
			}
			else
			{
				OnApplyMaterials();
			}
		}

		private void SetPrimaryColor(Color color)
		{
			Label.color = color;
		}

		private void UpdateFrameVisuals()
		{
			if (_frame == null)
			{
				return;
			}
			bool isSelected = base.PartScript.PartMaterialScript.IsSelected;
			bool isHighlighted = base.PartScript.PartMaterialScript.IsHighlighted;
			_tween?.Kill(complete: true);
			_tween = null;
			_frame.IsVisible = isSelected || isHighlighted;
			if (isSelected)
			{
				_frame.Opacity = 1f;
				_frame.Color = Constants.Colors.PrimaryLight;
				if (!_selected)
				{
					_frame.Scale = 1.125f * Vector3.one;
					_tween = DOTween.To(() => _frame.Scale.x, delegate(float x)
					{
						_frame.Scale = x * Vector3.one;
					}, 1f, 0.15f).SetEase(Ease.OutBack).SetUpdate(isIndependentUpdate: true);
				}
			}
			else if (isHighlighted)
			{
				_frame.Opacity = 0.75f;
				_frame.Color = Constants.Colors.HighlightColor;
				_frame.Scale = Vector3.one;
				_tween = DOTween.To(() => _frame.Scale.x, delegate(float x)
				{
					_frame.Scale = x * Vector3.one;
				}, 1.05f, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo)
					.SetUpdate(isIndependentUpdate: true);
			}
			_highlighted = isHighlighted;
			_selected = isSelected;
		}

		private void UpdateTextCollider()
		{
			if (_collider != null)
			{
				_collider.transform.localScale = new Vector3(Data.FontSize * Data.Width, Data.FontSize * Data.Height, 0.01f);
			}
			if (_frame != null)
			{
				_frame.SetCornerPoints(new Vector3((0f - Data.FontSize) * Data.Width / 2f, (0f - Data.FontSize) * Data.Height / 2f, 0f), new Vector3(Data.FontSize * Data.Width / 2f, Data.FontSize * Data.Height / 2f, 0f));
			}
		}
	}
}
