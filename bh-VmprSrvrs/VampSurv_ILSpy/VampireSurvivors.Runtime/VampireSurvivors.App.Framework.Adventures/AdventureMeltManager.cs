using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.UI;

namespace VampireSurvivors.App.Framework.Adventures;

public class AdventureMeltManager : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public AdventureMeltManager _003C_003E4__this;

		public Texture2D renderedTexture;

		public RenderTexture screenTexture;

		internal void _003CPerformMeltEffect_003Eb__0()
		{
			AdventureMeltManager adventureMeltManager = _003C_003E4__this;
			adventureMeltManager._CanvasGroup.alpha = 0f;
			AdventureMeltManager adventureMeltManager2 = _003C_003E4__this;
			adventureMeltManager2._isRunning = false;
			AdventureMeltManager adventureMeltManager3 = _003C_003E4__this;
			adventureMeltManager3._FullScreenImage.texture = null;
			UnityEngine.Object.Destroy(renderedTexture, 0f);
			UnityEngine.Object.Destroy(screenTexture, 0f);
		}
	}

	private sealed class _003CPerformMeltEffect_003Ed__15(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public AdventureMeltManager _003C_003E4__this;

		private _003C_003Ec__DisplayClass15_0 _003C_003E8__1;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_00a2: Expected I4, but got I8
			//IL_0136: Expected I4, but got O
			//IL_0247: Expected I4, but got O
			//IL_026e: Expected O, but got I4
			//IL_02ed: Expected O, but got Ref
			//IL_063a->IL0556: Incompatible stack heights: 1 vs 0
			//IL_0198->IL0556: Incompatible stack heights: 1 vs 0
			//IL_01ba->IL0556: Incompatible stack heights: 1 vs 0
			//IL_01fa->IL0556: Incompatible stack heights: 1 vs 0
			//IL_022a->IL0556: Incompatible stack heights: 1 vs 0
			//IL_065a->IL0556: Incompatible stack heights: 1 vs 0
			//IL_02aa->IL0556: Incompatible stack heights: 1 vs 0
			//IL_02cc->IL0556: Incompatible stack heights: 1 vs 0
			//IL_0311->IL0556: Incompatible stack heights: 1 vs 0
			//IL_0333->IL0556: Incompatible stack heights: 1 vs 0
			//IL_06b4->IL0556: Incompatible stack heights: 1 vs 0
			//IL_039c->IL0556: Incompatible stack heights: 1 vs 0
			//IL_03be->IL0556: Incompatible stack heights: 1 vs 0
			//IL_03f7->IL0556: Incompatible stack heights: 1 vs 0
			//IL_042c->IL0556: Incompatible stack heights: 1 vs 0
			//IL_045c->IL0556: Incompatible stack heights: 1 vs 0
			//IL_06d1->IL0556: Incompatible stack heights: 1 vs 0
			//IL_0548->IL0548: Incompatible stack heights: 1 vs 0
			AdventureMeltManager adventureMeltManager = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003Ec__DisplayClass15_0 obj = new _003C_003Ec__DisplayClass15_0();
				_003C_003E8__1 = obj;
				_003C_003Ec__DisplayClass15_0 obj2 = _003C_003E8__1;
				if (_003C_003E8__1 != null)
				{
					obj2._003C_003E4__this = _003C_003E4__this;
					WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
					_003C_003E2__current = waitForEndOfFrame;
					_003C_003E1__state = 1;
					return true;
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0548;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null && (object)adventureMeltManager._UICamera != null)
				{
					int pixelWidth = adventureMeltManager._UICamera.pixelWidth;
					if ((object)adventureMeltManager._UICamera != null)
					{
						int pixelHeight = adventureMeltManager._UICamera.pixelHeight;
						int num = (int)adventureMeltManager._UICamera;
						if ((object)adventureMeltManager._UICamera != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rbx_v10 (System.Int32)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rbx_v10 (System.Int32)+10]");
							Camera.get_pixelRect_Injected((IntPtr)0, out Rect _);
							_003C_003Ec__DisplayClass15_0 obj3 = _003C_003E8__1;
							int width = Screen.width;
							int height = Screen.height;
							RenderTextureFormat renderTextureFormat = default(RenderTextureFormat);
							RenderTexture screenTexture = new RenderTexture(width, height, 0, renderTextureFormat);
							if (_003C_003E8__1 != null)
							{
								obj3.screenTexture = screenTexture;
								_003C_003Ec__DisplayClass15_0 obj4 = _003C_003E8__1;
								if (_003C_003E8__1 != null && (object)adventureMeltManager._UICamera != null)
								{
									adventureMeltManager._UICamera.targetTexture = obj4.screenTexture;
									_003C_003Ec__DisplayClass15_0 obj5 = _003C_003E8__1;
									if (_003C_003E8__1 != null)
									{
										RenderTexture.SetActive(obj5.screenTexture);
										if ((object)adventureMeltManager._UICamera != null)
										{
											adventureMeltManager._UICamera.Render();
											int num2 = (int)_003C_003E8__1;
											bool linear = default(bool);
											IntPtr nativeTex = default(IntPtr);
											bool createUninitialized = default(bool);
											Texture2D texture2D = new Texture2D(pixelWidth, pixelHeight, TextureFormat.ARGB32, (int)renderTextureFormat, linear, nativeTex, createUninitialized, (MipmapLimitDescriptor)1);
											if (_003C_003E8__1 != null)
											{
												_003C_003Ec__DisplayClass15_0 obj6 = _003C_003E8__1;
												if (_003C_003E8__1 != null && (object)obj6.renderedTexture != null)
												{
													object obj7 = default(object);
													obj6.renderedTexture.ReadPixels((Rect)(&obj7), 0, 0);
													_003C_003Ec__DisplayClass15_0 obj8 = _003C_003E8__1;
													if (_003C_003E8__1 != null && (object)obj8.renderedTexture != null)
													{
														obj8.renderedTexture.Apply(updateMipmaps: true, makeNoLongerReadable: false);
														nint num3 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1300 @ rcx_v41 (Il2CppMethodInfo)+38]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
														}
														RenderTexture.SetActive_Injected((IntPtr)0);
														if ((object)adventureMeltManager._UICamera != null)
														{
															adventureMeltManager._UICamera.targetTexture = null;
															_003C_003Ec__DisplayClass15_0 obj9 = _003C_003E8__1;
															if (_003C_003E8__1 != null && (object)adventureMeltManager._FullScreenImage != null)
															{
																adventureMeltManager._FullScreenImage.texture = obj9.renderedTexture;
																if ((object)adventureMeltManager._CanvasGroup != null)
																{
																	adventureMeltManager._CanvasGroup.alpha = 1f;
																	if ((object)adventureMeltManager._MainMenuBackgroundManager != null)
																	{
																		adventureMeltManager._MainMenuBackgroundManager.ResetBackgroundToMainGame();
																		if ((object)adventureMeltManager._FullScreenImage != null)
																		{
																			Material material = adventureMeltManager._FullScreenImage.material;
																			if ((object)material != null)
																			{
																				material.SetFloatImpl(MeltProgressId, 0f);
																				TweenerCore<float, float, FloatOptions> tweenerCore = ShortcutExtensions.DOFloat(material, 1f, MeltProgressId, adventureMeltManager._MeltDuration);
																				TweenCallback tweenCallback = delegate
																				{
																					AdventureMeltManager adventureMeltManager2 = _003C_003E8__1._003C_003E4__this;
																					adventureMeltManager2._CanvasGroup.alpha = 0f;
																					AdventureMeltManager adventureMeltManager3 = _003C_003E8__1._003C_003E4__this;
																					adventureMeltManager3._isRunning = false;
																					AdventureMeltManager adventureMeltManager4 = _003C_003E8__1._003C_003E4__this;
																					adventureMeltManager4._FullScreenImage.texture = null;
																					UnityEngine.Object.Destroy(_003C_003E8__1.renderedTexture, 0f);
																					UnityEngine.Object.Destroy(_003C_003E8__1.screenTexture, 0f);
																				};
																				if (tweenerCore != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1366 @ rax_v62 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																					if ((nint)0 == 0)
																					{
																					}
																				}
																				TweenerCore<float, float, FloatOptions> t = TweenSettingsExtensions.SetDelay(tweenerCore, adventureMeltManager._MeltDelay);
																				TweenerCore<float, float, FloatOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t, adventureMeltManager._MeltDelay);
																				goto IL_0548;
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
			IL_0548:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private CanvasGroup _CanvasGroup;

	private RawImage _FullScreenImage;

	private MainMenuBackgroundManager _MainMenuBackgroundManager;

	private Camera _UICamera;

	private float _MeltDelay;

	private float _MeltDuration;

	private Ease _MeltEase;

	private AdventureManager _adventureManager;

	private bool _isRunning;

	private static readonly int MeltProgressId;

	private void Construct(AdventureManager adventureManager)
	{
		_adventureManager = adventureManager;
		AdventureManager adventureManager2 = _adventureManager;
		Action b = OnAdventureExit;
		Delegate obj = Delegate.Combine(adventureManager2._003COnAdventureExitEvent_003Ek__BackingField, b);
		if ((object)obj != null)
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			bool flag2 = (object)obj2 == null;
			obj = obj2;
			if (flag2)
			{
				throw new InvalidCastException();
			}
		}
		adventureManager2._003COnAdventureExitEvent_003Ek__BackingField = (Action)obj;
	}

	private void Awake()
	{
	}

	private void Start()
	{
		_isRunning = false;
	}

	private void OnDestroy()
	{
		if (_adventureManager == null)
		{
			return;
		}
		AdventureManager adventureManager = _adventureManager;
		Action value = OnAdventureExit;
		Delegate obj = Delegate.Remove(adventureManager._003COnAdventureExitEvent_003Ek__BackingField, value);
		if ((object)obj != null)
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			bool flag2 = (object)obj2 == null;
			obj = obj2;
			if (flag2)
			{
				throw new InvalidCastException();
			}
		}
		adventureManager._003COnAdventureExitEvent_003Ek__BackingField = (Action)obj;
	}

	private void OnAdventureExit()
	{
		if (!_isRunning)
		{
			_003CPerformMeltEffect_003Ed__15 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj);
			_isRunning = true;
		}
	}

	private IEnumerator PerformMeltEffect()
	{
		_003CPerformMeltEffect_003Ed__15 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public AdventureMeltManager()
	{
		//IL_0036: Expected I, but got O
		_MeltDelay = 2f;
		_MeltDuration = 3f;
		_MeltEase = Ease.InQuad;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	static AdventureMeltManager()
	{
		int meltProgressId = Shader.PropertyToID("_Progress");
		MeltProgressId = meltProgressId;
	}
}
