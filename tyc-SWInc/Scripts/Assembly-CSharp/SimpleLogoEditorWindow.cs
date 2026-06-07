using System;
using Achievements;
using UnityEngine;

public class SimpleLogoEditorWindow : MonoBehaviour
{
	public GUIWindow Window;

	public SDFSimpleEditor MainEditor;

	[NonSerialized]
	public Action<byte[]> OnSave;

	public void Show(byte[] logo, Action<byte[]> onSave)
	{
		OnSave = onSave;
		Window.Show();
		MainEditor.LoadTreeData(logo);
		AchievementController.SetInteraction(AchievementController.Mechanics.CustomLogos);
	}

	public void SaveAndExit()
	{
		byte[] data = GetData();
		if (data != null)
		{
			GameData.SaveLogo(SDFCreator.GetTreeString(data));
			OnSave(data);
			Window.Close();
		}
	}

	public byte[] GetData()
	{
		try
		{
			SDFCreator.ISDFOutput iSDFOutput = SDFSimpleEditor.CreateTree(MainEditor.Layers, false);
			if (iSDFOutput.CountNodes() > 25)
			{
				WindowManager.Instance.ShowMessageBox("LogoComplexityLimit".Loc(), true, DialogWindow.DialogType.Error, Window);
				return null;
			}
			if (!iSDFOutput.IsValid())
			{
				throw new Exception();
			}
			return SDFCreator.SerializeTree(iSDFOutput);
		}
		catch (Exception)
		{
			WindowManager.Instance.ShowMessageBox("LogoError".Loc(), true, DialogWindow.DialogType.Error, Window);
			return null;
		}
	}

	public void OpenAdvanced()
	{
		byte[] array = ((MainEditor.Layers.Count == 0) ? null : GetData());
		if (array != null || MainEditor.Layers.Count == 0)
		{
			MainEditor.AdvancedEditor.Show(array, OnSave);
			if (Window.Parent != null)
			{
				MainEditor.AdvancedEditor.Window.SetParentWindow(Window.Parent);
			}
			Window.Close();
		}
	}
}
