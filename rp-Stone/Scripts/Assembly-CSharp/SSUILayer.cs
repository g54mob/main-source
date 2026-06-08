using System.Collections.Generic;
using UnityEngine;

public class SSUILayer : MonoBehaviour, IAsciiObject
{
	public UIPanel panelPrefab;

	public UIButton buttonPrefab;

	public UITextBox textBoxPrefab;

	public UISprite spritePrefab;

	public UICanvas canvasPrefab;

	public UIPanel uiRootPanel;

	private Stack<UIButton> buttonPool = new Stack<UIButton>();

	private Stack<UIPanel> panelPool = new Stack<UIPanel>();

	private Stack<UITextBox> textBoxPool = new Stack<UITextBox>();

	private Stack<UISprite> spritePool = new Stack<UISprite>();

	private Stack<UICanvas> canvasPool = new Stack<UICanvas>();

	private Dictionary<string, int> customStyles = new Dictionary<string, int>();

	private static SSUILayer instance;

	public static SSUILayer singleton => instance;

	public void Clear()
	{
		uiRootPanel.Clear();
		uiRootPanel.ResetControl();
		uiRootPanel.isVisible = false;
	}

	public int AddStyle(string styleStr)
	{
		if (customStyles.ContainsKey(styleStr))
		{
			return customStyles[styleStr];
		}
		int num = BoxDrawing.AddStyle(styleStr.ToCharArray());
		customStyles.Add(styleStr, num);
		return num;
	}

	public UIPanel AddPanel()
	{
		UIPanel uIPanel = ((panelPool.Count <= 0) ? Object.Instantiate(panelPrefab) : panelPool.Pop());
		uIPanel.ResetControl();
		uiRootPanel.AddChild(uIPanel);
		return uIPanel;
	}

	public UIButton AddButton()
	{
		UIButton uIButton = ((buttonPool.Count <= 0) ? Object.Instantiate(buttonPrefab) : buttonPool.Pop());
		uIButton.ResetControl();
		uiRootPanel.AddChild(uIButton);
		return uIButton;
	}

	public UITextBox AddText()
	{
		UITextBox uITextBox = ((textBoxPool.Count <= 0) ? Object.Instantiate(textBoxPrefab) : textBoxPool.Pop());
		uITextBox.ResetControl();
		uiRootPanel.AddChild(uITextBox);
		return uITextBox;
	}

	public UISprite AddAnim(string spriteData)
	{
		UISprite uISprite = ((spritePool.Count <= 0) ? Object.Instantiate(spritePrefab) : spritePool.Pop());
		uISprite.Load(spriteData);
		uISprite.ResetControl();
		uiRootPanel.AddChild(uISprite);
		return uISprite;
	}

	public UICanvas AddCanvas()
	{
		UICanvas uICanvas = ((canvasPool.Count <= 0) ? Object.Instantiate(canvasPrefab) : canvasPool.Pop());
		uICanvas.ResetControl();
		uiRootPanel.AddChild(uICanvas);
		return uICanvas;
	}

	public void Recycle(UIControl control)
	{
		UIPanel uIPanel = control as UIPanel;
		if (uIPanel != null)
		{
			List<UIControl> children = uIPanel.GetChildren();
			for (int num = children.Count - 1; num >= 0; num--)
			{
				UIControl control2 = children[num];
				Recycle(control2);
			}
			panelPool.Push(uIPanel);
			uIPanel.ResetControl();
			return;
		}
		UIButton uIButton = control as UIButton;
		if (uIButton != null)
		{
			buttonPool.Push(uIButton);
			return;
		}
		UITextBox uITextBox = control as UITextBox;
		if (uITextBox != null)
		{
			textBoxPool.Push(uITextBox);
			return;
		}
		UISprite uISprite = control as UISprite;
		if (uISprite != null)
		{
			spritePool.Push(uISprite);
			return;
		}
		UICanvas uICanvas = control as UICanvas;
		if (uICanvas != null)
		{
			canvasPool.Push(uICanvas);
		}
	}

	public void UpdateTic()
	{
		uiRootPanel.UpdateTic();
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		uiRootPanel.PositionX = 0;
		uiRootPanel.PositionY = 0;
		uiRootPanel.Width = r.width;
		uiRootPanel.Height = r.height;
		uiRootPanel.Draw(r, offsetX, offsetY);
	}

	private void Awake()
	{
		instance = this;
		uiRootPanel = Object.Instantiate(panelPrefab);
		uiRootPanel.isVisible = false;
	}
}
