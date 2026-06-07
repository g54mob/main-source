using System.Xml.Linq;

namespace MG_BlocksEngine2.Serializer
{
	public static class BE2_BlockXML
	{
		public static XElement SBlockToXElement(BE2_SerializableBlock serializableBlock)
		{
			XElement xElement = new XElement("Block");
			xElement.Add(new XElement("blockName", serializableBlock.blockName));
			xElement.Add(new XElement("position", serializableBlock.position));
			xElement.Add(new XElement("varManagerName", serializableBlock.varManagerName));
			xElement.Add(new XElement("varName", serializableBlock.varName));
			xElement.Add(new XElement("defineID", serializableBlock.defineID));
			xElement.Add(new XElement("isLocalVar", serializableBlock.isLocalVar));
			XElement xElement2 = new XElement("defineItems");
			xElement.Add(xElement2);
			foreach (DefineItem defineItem in serializableBlock.defineItems)
			{
				XElement xElement3 = new XElement("Item");
				xElement2.Add(xElement3);
				xElement3.Add(new XElement("type", defineItem.type));
				xElement3.Add(new XElement("value", defineItem.value));
			}
			XElement xElement4 = new XElement("sections");
			xElement.Add(xElement4);
			foreach (BE2_SerializableSection section in serializableBlock.sections)
			{
				XElement content = SSectionToXElement(section);
				xElement4.Add(content);
			}
			XElement content2 = SOuterAreaToXElement(serializableBlock.outerArea);
			xElement.Add(content2);
			return xElement;
		}

		public static XElement SSectionToXElement(BE2_SerializableSection serializableSection)
		{
			XElement xElement = new XElement("Section");
			XElement xElement2 = new XElement("childBlocks");
			xElement.Add(xElement2);
			foreach (BE2_SerializableBlock childBlock in serializableSection.childBlocks)
			{
				XElement content = SBlockToXElement(childBlock);
				xElement2.Add(content);
			}
			XElement xElement3 = new XElement("inputs");
			xElement.Add(xElement3);
			foreach (BE2_SerializableInput input in serializableSection.inputs)
			{
				XElement content2 = SInputToXElement(input);
				xElement3.Add(content2);
			}
			return xElement;
		}

		public static XElement SOuterAreaToXElement(BE2_SerializableOuterArea serializableOuterArea)
		{
			XElement xElement = new XElement("OuterArea");
			XElement xElement2 = new XElement("childBlocks");
			xElement.Add(xElement2);
			foreach (BE2_SerializableBlock childBlock in serializableOuterArea.childBlocks)
			{
				XElement content = SBlockToXElement(childBlock);
				xElement2.Add(content);
			}
			return xElement;
		}

		public static XElement SInputToXElement(BE2_SerializableInput serializableInput)
		{
			XElement xElement = new XElement("Input");
			xElement.Add(new XElement("isOperation", serializableInput.isOperation));
			xElement.Add(new XElement("value", serializableInput.value));
			if (serializableInput.isOperation)
			{
				XElement xElement2 = new XElement("operation");
				xElement.Add(xElement2);
				XElement content = SBlockToXElement(serializableInput.operation);
				xElement2.Add(content);
			}
			return xElement;
		}

		public static BE2_SerializableBlock XElementToSBlock(XElement xBlock)
		{
			BE2_SerializableBlock bE2_SerializableBlock = new BE2_SerializableBlock();
			bE2_SerializableBlock.blockName = xBlock.Element("blockName").Value;
			bE2_SerializableBlock.position = BE2_BlockXMLUtils.StringToVector3(xBlock.Element("position").Value);
			bE2_SerializableBlock.varManagerName = xBlock.Element("varManagerName")?.Value;
			bE2_SerializableBlock.varName = xBlock.Element("varName").Value;
			bE2_SerializableBlock.defineID = xBlock.Element("defineID").Value;
			bE2_SerializableBlock.isLocalVar = xBlock.Element("isLocalVar").Value;
			foreach (XElement item2 in xBlock.Element("defineItems").Elements("Item"))
			{
				bE2_SerializableBlock.defineItems.Add(new DefineItem(item2.Element("type").Value, item2.Element("value").Value));
			}
			foreach (XElement item3 in xBlock.Element("sections").Elements("Section"))
			{
				BE2_SerializableSection item = XElementToSSection(item3);
				bE2_SerializableBlock.sections.Add(item);
			}
			BE2_SerializableOuterArea outerArea = XElementToSOuterArea(xBlock.Element("OuterArea"));
			bE2_SerializableBlock.outerArea = outerArea;
			return bE2_SerializableBlock;
		}

		public static BE2_SerializableSection XElementToSSection(XElement xSection)
		{
			BE2_SerializableSection bE2_SerializableSection = new BE2_SerializableSection();
			foreach (XElement item3 in xSection.Element("childBlocks").Elements("Block"))
			{
				BE2_SerializableBlock item = XElementToSBlock(item3);
				bE2_SerializableSection.childBlocks.Add(item);
			}
			foreach (XElement item4 in xSection.Element("inputs").Elements("Input"))
			{
				BE2_SerializableInput item2 = XElementToSInput(item4);
				bE2_SerializableSection.inputs.Add(item2);
			}
			return bE2_SerializableSection;
		}

		public static BE2_SerializableOuterArea XElementToSOuterArea(XElement xOuterArea)
		{
			BE2_SerializableOuterArea bE2_SerializableOuterArea = new BE2_SerializableOuterArea();
			foreach (XElement item2 in xOuterArea.Element("childBlocks").Elements("Block"))
			{
				BE2_SerializableBlock item = XElementToSBlock(item2);
				bE2_SerializableOuterArea.childBlocks.Add(item);
			}
			return bE2_SerializableOuterArea;
		}

		public static BE2_SerializableInput XElementToSInput(XElement xInput)
		{
			BE2_SerializableInput bE2_SerializableInput = new BE2_SerializableInput();
			bE2_SerializableInput.isOperation = xInput.Element("isOperation").Value == "true";
			bE2_SerializableInput.value = xInput.Element("value").Value;
			if (bE2_SerializableInput.isOperation)
			{
				BE2_SerializableBlock operation = XElementToSBlock(xInput.Element("operation").Element("Block"));
				bE2_SerializableInput.operation = operation;
			}
			return bE2_SerializableInput;
		}
	}
}
