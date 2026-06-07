using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Examples
{
	internal class XmlLayout_Example_TestItOut : XmlLayoutController
	{
		public XmlLayout_Example_MessageDialog MessageDialog;

		public XmlLayout_Example_ExampleMenu ExampleMenu;

		private string Xml;

		private bool viewPortExpanded;

		private void Start()
		{
			Empty();
		}

		public override void Show()
		{
			base.Show();
			ScrollToTop();
		}

		public override void Hide(Action onCompleteCallback = null)
		{
			ExampleMenu.SelectExample();
		}

		private void UpdateCodeInputField()
		{
			base.xmlLayout.GetElementById<InputField>("codeInputField").text = Xml.Trim();
			ScrollToTop();
		}

		private void ScrollToTop()
		{
			base.xmlLayout.GetElementById<ScrollRect>("codeInputScrollView").verticalNormalizedPosition = 1f;
		}

		private void XmlChanged(string newXml)
		{
			Xml = ((newXml != null) ? newXml.Trim() : "");
		}

		private void ToggleViewportSize()
		{
			XmlElement elementById = base.xmlLayout.GetElementById("output");
			XmlElement elementById2 = base.xmlLayout.GetElementById("expandedOutput");
			if (!viewPortExpanded)
			{
				elementById2.gameObject.SetActive(value: true);
				XmlElement elementById3 = base.xmlLayout.GetElementById("expandedOutputPanel");
				elementById.transform.SetParent(elementById3.transform);
			}
			else
			{
				XmlElement elementById4 = base.xmlLayout.GetElementById("outputContainer");
				elementById.transform.SetParent(elementById4.transform);
				elementById2.gameObject.SetActive(value: false);
			}
			viewPortExpanded = !viewPortExpanded;
			UpdateDisplay();
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			if (Application.isPlaying && parseResult == ParseXmlResult.Changed)
			{
				UpdateDisplay();
			}
		}

		public void UpdateDisplay()
		{
			XmlLayoutTimer.AtEndOfFrame(_UpdateDisplay, this);
		}

		private void _UpdateDisplay()
		{
			base.xmlLayout.GetElementById<InputField>("lineNumbers").text = string.Join("\r\n", (from i in Enumerable.Range(1, 100)
				select i.ToString().PadLeft(2, '0')).ToArray());
			XmlElement outputField = base.xmlLayout.GetElementById("output");
			XmlLayout outputFieldXmlLayout = outputField.gameObject.GetComponent<XmlLayout>() ?? outputField.gameObject.AddComponent<XmlLayout>();
			outputField.ApplyAttributes(GetOutputFieldAttributes());
			outputFieldXmlLayout.gameObject.SetActive(value: true);
			outputFieldXmlLayout.Hide(delegate
			{
				outputFieldXmlLayout.gameObject.SetActive(value: true);
				outputFieldXmlLayout.Xml = Xml;
				try
				{
					ILogHandler logHandler = Debug.unityLogger.logHandler;
					Debug.unityLogger.logHandler = new TestLogHandler(MessageDialog, logHandler);
					outputFieldXmlLayout.RebuildLayout(forceEvenIfXmlUnchanged: false, throwExceptionIfXmlIsInvalid: true);
					Debug.unityLogger.logHandler = logHandler;
				}
				catch (Exception ex)
				{
					MessageDialog.Show("Xml Parse Error", ex.Message);
				}
				outputField.ApplyAttributes(GetOutputFieldAttributes());
				outputFieldXmlLayout.Show();
			});
		}

		private AttributeDictionary GetOutputFieldAttributes()
		{
			return new AttributeDictionary
			{
				{ "ShowAnimation", "Grow" },
				{ "HideAnimation", "FadeOut" },
				{ "AnimationDuration", "0.2" }
			};
		}

		private void Empty()
		{
			Xml = "\r\n<XmlLayout>\r\n    <Include path=\"Xml/Styles.xml\" /> \r\n\r\n\r\n</XmlLayout>\r\n            ";
			UpdateCodeInputField();
			UpdateDisplay();
		}

		private void ExampleA()
		{
			Xml = "\r\n<XmlLayout>        \r\n    <Defaults>\r\n        <Text alignment=\"MiddleCenter\"\r\n              fontStyle=\"Bold\" \r\n              fontSize=\"18\"\r\n              color=\"white\" />\r\n\r\n        <Text class=\"header\" \r\n              color=\"#00FF00\"               \r\n              fontSize=\"24\"\r\n              outline=\"black\" />\r\n\r\n        <Image preserveAspect=\"true\" />       \r\n    </Defaults>\r\n    \r\n    <TableLayout cellPadding=\"10\" cellSpacing=\"5\">\r\n        <Row preferredHeight=\"48\">\r\n            <Cell columnSpan=\"3\">\r\n                <Text class=\"header\">Gems</Text>\r\n            </Cell>            \r\n        </Row>\r\n        <Row>\r\n            <Cell>\r\n                <Image image=\"Sprites/Shop/gemRed\" />\r\n            </Cell>\r\n            <Cell>\r\n                <Image image=\"Sprites/Shop/gemBlue\" />\r\n            </Cell>\r\n            <Cell>\r\n                <Image image=\"Sprites/Shop/gemGreen\" />\r\n            </Cell>\r\n        </Row>\r\n        <Row preferredHeight=\"48\">\r\n            <Cell><Text>Red</Text></Cell>\r\n            <Cell><Text>Blue</Text></Cell>\r\n            <Cell><Text>Green</Text></Cell>\r\n        </Row>\r\n    </TableLayout>\r\n</XmlLayout>\r\n            ";
			UpdateCodeInputField();
			UpdateDisplay();
		}

		private void ExampleB()
		{
			Xml = "\r\n<XmlLayout>\r\n    <Include path=\"Xml/Styles.xml\" /> \r\n\r\n    <VerticalLayout padding=\"20\" spacing=\"5\">\r\n        <Button>Button 1</Button>\r\n        <Button>Button 2</Button>\r\n        <Button>Button 3</Button>\r\n        <Button>Button 4</Button>\r\n        <Button>Button 5</Button>\r\n        <Button>Button 6</Button>\r\n        <Button>Button 7</Button>\r\n        <Button>Button 8</Button>\r\n    </VerticalLayout>\r\n</XmlLayout>\r\n            ";
			UpdateCodeInputField();
			UpdateDisplay();
		}

		private void ExampleC()
		{
			Xml = "\r\n<XmlLayout>\r\n    <Include path=\"Xml/Styles.xml\" />\r\n\r\n    <Defaults>\r\n        <Panel class=\"cornerPanel\" \r\n               width=\"100\" \r\n               height=\"50\" \r\n               color=\"rgba(0,0.5,0,0.5)\"\r\n               image=\"Sprites/Outline_With_Background\" \r\n        />\r\n\r\n        <Text color=\"#00FF00\" \r\n              fontStyle=\"Bold\" \r\n              alignment=\"MiddleCenter\" />\r\n    </Defaults>\r\n\r\n    <Panel width=\"90%\" \r\n           height=\"90%\" \r\n           image=\"Sprites/Outline\"\r\n           color=\"rgb(0.5,0.5,0.5)\">\r\n        <Panel class=\"cornerPanel\" \r\n               rectAlignment=\"UpperLeft\">\r\n            <Text>Upper Left</Text>\r\n        </Panel>\r\n\r\n        <Panel class=\"cornerPanel\" \r\n               rectAlignment=\"UpperRight\">\r\n            <Text>Upper Right</Text>\r\n        </Panel>\r\n\r\n        <Image image=\"Sprites/Shop/coin\"\r\n               width=\"100\" \r\n               height=\"100\" \r\n               rectAlignment=\"MiddleCenter\"\r\n               preserveAspect=\"true\"\r\n               allowDragging=\"true\" \r\n               restrictDraggingToParentBounds=\"false\" />\r\n\r\n        <Text offsetXY=\"0,-48\" raycastTarget=\"false\">Try dragging the coin!</Text>\r\n\r\n        <Panel class=\"cornerPanel\" \r\n               rectAlignment=\"LowerLeft\">\r\n            <Text>Lower Left</Text>\r\n        </Panel>\r\n\r\n        <Panel class=\"cornerPanel\" \r\n               rectAlignment=\"LowerRight\">\r\n            <Text>Lower Right</Text>\r\n        </Panel>\r\n    </Panel>\r\n\r\n</XmlLayout>\r\n            ";
			UpdateCodeInputField();
			UpdateDisplay();
		}
	}
}
