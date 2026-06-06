using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.UI.Cartographic
{
	[RequireComponent(typeof(UIDocument))]
	public class CartographicUIEffect : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CApplyWhenReady_003Ed__56 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CartographicUIEffect _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CApplyWhenReady_003Ed__56(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Header("Shader")]
		[Tooltip("Assign the Brewery/CartographicUI shader")]
		[SerializeField]
		private Shader cartographicShader;

		[Header("Theme Stylesheet")]
		[Tooltip("Assign CartographicShelf.uss")]
		[SerializeField]
		private StyleSheet themeStyleSheet;

		[Header("Paper Color")]
		[SerializeField]
		private Color paperColor;

		[SerializeField]
		private Color paperDarkColor;

		[SerializeField]
		[Range(0f, 1f)]
		private float paperFiber;

		[SerializeField]
		[Range(0f, 1f)]
		private float ageStain;

		[Header("Brewery Details")]
		[SerializeField]
		[Range(0f, 1f)]
		private float waterStainIntensity;

		[SerializeField]
		[Range(0f, 1f)]
		private float inkSpeckles;

		[SerializeField]
		[Range(0f, 1f)]
		private float foldCrease;

		[Header("Decoration")]
		[SerializeField]
		private Color contourColor;

		[SerializeField]
		private float contourCount;

		[SerializeField]
		private Color gridColor;

		[SerializeField]
		private float gridSpacing;

		[Header("Border & Vignette")]
		[SerializeField]
		[Range(0f, 0.08f)]
		private float inkBorderWidth;

		[SerializeField]
		[Range(0f, 0.02f)]
		private float inkBorderWobble;

		[SerializeField]
		[Range(0f, 1f)]
		private float cornerWear;

		[SerializeField]
		[Range(0f, 2f)]
		private float vignetteStrength;

		[Header("Texture Resolution")]
		[SerializeField]
		private int panelSize;

		[SerializeField]
		private int headerHeight;

		[SerializeField]
		private int infoSize;

		private static readonly int _PaperColor;

		private static readonly int _PaperDarkColor;

		private static readonly int _PaperScale;

		private static readonly int _PaperFiber;

		private static readonly int _AgeStain;

		private static readonly int _WaterStain;

		private static readonly int _SpeckleAmount;

		private static readonly int _FoldCrease;

		private static readonly int _ContourColor;

		private static readonly int _ContourCount;

		private static readonly int _ContourThickness;

		private static readonly int _GridColor;

		private static readonly int _GridSpacing;

		private static readonly int _GridThickness;

		private static readonly int _InkBorderWidth;

		private static readonly int _InkBorderColor;

		private static readonly int _InkBorderWobble;

		private static readonly int _CornerWear;

		private static readonly int _VignetteStrength;

		private static readonly int _VignetteColor;

		private static readonly int _Variant;

		private static readonly int _AspectRatio;

		private UIDocument uiDocument;

		private Material material;

		private readonly List<Texture2D> generatedTextures;

		private Texture2D panelTex;

		private Texture2D headerTex;

		private Texture2D infoTex;

		private Texture2D bottlingTex;

		private bool isApplied;

		private Coroutine applyRoutine;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void SetMaterialDefaults()
		{
		}

		private void GenerateAllTextures()
		{
		}

		private Texture2D BakeTexture(int width, int height, float variant, Action<Material> overrides = null)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CApplyWhenReady_003Ed__56))]
		private IEnumerator ApplyWhenReady()
		{
			return null;
		}

		private void ApplyToUI(VisualElement root)
		{
		}

		private void RevertUI()
		{
		}

		private static void SetBackground(VisualElement root, string elementName, Texture2D tex)
		{
		}

		private static void ClearBackground(VisualElement root, string elementName)
		{
		}

		private void Cleanup()
		{
		}

		[ContextMenu("Refresh Cartographic Theme")]
		public void Refresh()
		{
		}
	}
}
