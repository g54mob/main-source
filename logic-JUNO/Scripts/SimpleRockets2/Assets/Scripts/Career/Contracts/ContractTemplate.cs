using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Career.Contracts.Params;
using ModApi.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Career.Contracts
{
	public class ContractTemplate
	{
		public class ContractPrereqs
		{
			public string[] ContractIds { get; }

			public string[] CraftNodes { get; }

			public string[] TechNodeIds { get; }

			public ContractPrereqs(XElement xml)
			{
				ContractIds = xml?.GetStringAttribute("contracts")?.Split(new char[1] { ',' });
				TechNodeIds = xml?.GetStringAttribute("techNodes")?.Split(new char[1] { ',' });
				CraftNodes = xml?.GetStringAttribute("craftNodes")?.Split(new char[1] { ',' });
			}
		}

		public const string ElementName = "ContractTemplate";

		private XElement _originalContractXml;

		private XElement _xml;

		public bool Disabled { get; set; }

		public string Id { get; internal set; }

		public bool IsDebug { get; set; }

		public string Name { get; }

		public ContractPrereqs Prereqs { get; private set; }

		public StringProcessor StringProcessor { get; }

		public ContractTemplate(XElement xml)
		{
			_originalContractXml = xml.Element("Contract");
			Prereqs = new ContractPrereqs(xml.Element("Prereqs"));
			Id = _originalContractXml.GetStringAttribute("id");
			Name = _originalContractXml.GetStringAttribute("name");
			IsDebug = xml.GetBoolAttribute("debug");
			Disabled = xml.GetBoolAttribute("disabled");
			StringProcessor = new StringProcessor();
			_xml = xml;
		}

		public XElement GenerateContractXml(IContractContext contractContext)
		{
			ContractParamContext paramContext = new ContractParamContext(this, contractContext);
			ProcessParams(_xml.Element("Params"), paramContext, StringProcessor, Id);
			if (IsDebug)
			{
				string text = string.Empty;
				foreach (KeyValuePair<string, IStringProcessorParam> item in StringProcessor.Params)
				{
					text = text + item.Key + "\t" + item.Value.Value + "\n";
				}
				Debug.Log(text);
			}
			XElement xElement = new XElement(_originalContractXml);
			ProcessAttributes(xElement, StringProcessor, Id, paramContext);
			return xElement;
		}

		private static ContractParam CreateParam(XElement xml, ContractParamContext paramContext)
		{
			return xml.Name.LocalName switch
			{
				"Completions" => new CompletionsParam(xml, paramContext), 
				"Const" => new ConstParam(xml), 
				"Expression" => new ExpressionParam(xml, paramContext), 
				"LatLonAgl" => new LatLonAglParam(xml), 
				"List" => new ListParam(xml), 
				"Random" => new RandomParam(xml, paramContext), 
				"RandomList" => new RandomListParam(xml), 
				"UniqueString" => new UniqueStringParam(xml), 
				_ => throw new NotImplementedException("Unknown contract param type: " + xml.Name.LocalName), 
			};
		}

		private static void ProcessAttributes(XElement element, StringProcessor stringProcessor, string contractTemplateId, ContractParamContext paramContext)
		{
			foreach (XAttribute item in element.Attributes())
			{
				try
				{
					item.Value = stringProcessor.ProcessString(item.Value);
				}
				catch (Exception ex)
				{
					string message = $"Error processing attribute {item.Name}=\"{item.Value}\" in contract template '{contractTemplateId}': {ex.Message}.";
					Debug.LogError(message);
					throw new Exception(message, ex);
				}
			}
			List<XElement> list = element.Elements().ToList();
			if (element.Name == "Template.Repeat")
			{
				int intAttribute = element.GetIntAttribute("count");
				for (int i = 0; i < intAttribute; i++)
				{
					paramContext.RepeatIndex = i;
					foreach (XElement item2 in list)
					{
						XElement xElement = new XElement(item2);
						ProcessAttributes(xElement, stringProcessor, contractTemplateId, paramContext);
						if (xElement.Name != "Template.Params")
						{
							element.AddBeforeSelf(xElement);
						}
					}
				}
				element.Remove();
				paramContext.RepeatIndex = 0;
				return;
			}
			if (element.Name == "Template.Params")
			{
				ProcessParams(element, paramContext, stringProcessor, contractTemplateId);
				return;
			}
			foreach (XElement item3 in list)
			{
				ProcessAttributes(item3, stringProcessor, contractTemplateId, paramContext);
			}
		}

		private static void ProcessParams(XElement paramsElement, ContractParamContext paramContext, StringProcessor stringProcessor, string contractTemplateId)
		{
			List<XElement> list = paramsElement?.Elements()?.ToList();
			if (list == null || list.Count <= 0)
			{
				return;
			}
			foreach (XElement item in list)
			{
				try
				{
					XElement xElement = new XElement(item);
					ProcessAttributes(xElement, stringProcessor, contractTemplateId, paramContext);
					ContractParam contractParam = CreateParam(xElement, paramContext);
					stringProcessor.SetParam(contractParam.Name, contractParam);
				}
				catch (Exception innerException)
				{
					throw new ContractException($"Failed to create param for contract template {contractTemplateId}. Param XML: {item}", innerException);
				}
			}
		}
	}
}
