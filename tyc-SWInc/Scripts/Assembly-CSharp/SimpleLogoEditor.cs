using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleLogoEditor : MonoBehaviour
{
	public Button ColorButtonPrefab;

	public Slider SliderPrefab;

	public RectTransform ParameterPanel;

	public GUIWindow Window;

	public RawImage LogoView;

	private RenderTexture LogoTexture;

	public SimpleLogoEditorWindow AdvancedLogoWindow;

	public SDFDownloader Downloader;

	[NonSerialized]
	public SDFCreator.ISDFNode Logo;

	[NonSerialized]
	public Dictionary<string, List<SDFCreator.SDFParameterExport>> Parameters;

	public void ClearParameters()
	{
		for (int num = ParameterPanel.childCount - 1; num >= 0; num--)
		{
			UnityEngine.Object.Destroy(ParameterPanel.GetChild(num).gameObject);
		}
	}

	public void Show()
	{
		Logo = ActorCustomization.Instance.Logo;
		LogoTexture = new RenderTexture(256, 256, 0, RenderTextureFormat.ARGB32);
		LogoView.texture = LogoTexture;
		ClearParameters();
		GenerateParameters(ActorCustomization.Instance.LogoParameters);
		RefreshLogo();
		Window.OnClose = OnClose;
		Window.Show();
		Downloader.OnLogoDownload = delegate(string x)
		{
			Logo = SDFCreator.LoadSDFTree(SDFCreator.GetTreeFromString(x));
			ClearParameters();
			ActorCustomization.Instance.LogoParameters = null;
			GenerateParameters(ActorCustomization.Instance.LogoParameters);
			RefreshLogo();
		};
		Downloader.ShowDefault();
	}

	public void AdvancedMode()
	{
		if (Input.GetKey(KeyCode.LeftShift))
		{
			AdvancedLogoWindow.MainEditor.AdvancedEditor.Show(SDFCreator.SerializeTree(Logo), OnSave);
		}
		else
		{
			AdvancedLogoWindow.Show(SDFCreator.SerializeTree(Logo), OnSave);
		}
		Window.Close();
	}

	private void OnSave(byte[] x)
	{
		ActorCustomization.Instance.Logo = SDFCreator.LoadSDFTree(x);
		ActorCustomization.Instance.LogoParameters = null;
		ActorCustomization.Instance.RefreshLogo();
	}

	public void RefreshLogo()
	{
		Logo.Execute(256, LogoTexture, Matrix4x4.identity);
	}

	public void OnClose()
	{
		ActorCustomization.Instance.Logo = Logo;
		ActorCustomization.Instance.LogoParameters = Parameters;
		ActorCustomization.Instance.RefreshLogo();
		UnityEngine.Object.Destroy(LogoTexture);
	}

	public void GenerateParameters(Dictionary<string, List<SDFCreator.SDFParameterExport>> exports)
	{
		Dictionary<Color, List<SDFCreator.SDFParameterExport>> dictionary = new Dictionary<Color, List<SDFCreator.SDFParameterExport>>();
		SDFCreator.GetColorParameters(Logo, new HashSet<SDFCreator.ISDFNode>(), dictionary);
		foreach (List<SDFCreator.SDFParameterExport> c in dictionary.Values)
		{
			Button cb = UnityEngine.Object.Instantiate(ColorButtonPrefab);
			cb.onClick.AddListener(delegate
			{
				ColorWindow colorWindow = WindowManager.SpawnColorDialog(delegate(Color x)
				{
					foreach (SDFCreator.SDFParameterExport item in c)
					{
						item.Execute(x);
					}
					cb.image.color = x;
					RefreshLogo();
				}, cb.image.color);
				colorWindow.Window.SetParentWindow(Window, true);
				colorWindow.Window.HideBlockPanel = false;
			});
			cb.transform.SetParent(ParameterPanel, false);
			cb.image.color = c.First().GetColor();
		}
		if (exports == null)
		{
			return;
		}
		foreach (List<SDFCreator.SDFParameterExport> e in exports.Values)
		{
			Slider slider = UnityEngine.Object.Instantiate(SliderPrefab);
			slider.value = e.First().GetFloat();
			slider.onValueChanged.AddListener(delegate(float x)
			{
				foreach (SDFCreator.SDFParameterExport item2 in e)
				{
					item2.Execute(x);
				}
				RefreshLogo();
			});
			slider.transform.SetParent(ParameterPanel, false);
		}
	}

	public void Randomize()
	{
		ClearParameters();
		Parameters = new Dictionary<string, List<SDFCreator.SDFParameterExport>>();
		Logo = SDFCreator.Instance.GetRandomTree("Final").Generate(Parameters);
		GenerateParameters(Parameters);
		RefreshLogo();
	}

	public void UseCode()
	{
		WindowManager.SpawnInputDialog("LogoCodeText".Loc(), "Logo".Loc(), "", delegate(string x)
		{
			try
			{
				Logo = SDFCreator.LoadSDFTree(SDFCreator.GetTreeFromString(x));
				Parameters = null;
				RefreshLogo();
				ClearParameters();
				GenerateParameters(null);
			}
			catch (Exception)
			{
				WindowManager.Instance.ShowMessageBox("LogoCodeError".Loc(), true, DialogWindow.DialogType.Error);
			}
		}, null, 0, Window);
	}

	private void OnDestroy()
	{
		if (LogoTexture != null)
		{
			UnityEngine.Object.Destroy(LogoTexture);
		}
	}
}
