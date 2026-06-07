using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using EncryptString;
using UnityEngine;

public static class CreationModelBuilder
{
	private const string TAG_CREATION = "creation";

	private const string TAG_BLOCKS = "blocks";

	private const string TAG_BLOCK = "block";

	private const string TAG_BODY = "body";

	private const string TAG_FIXED_JOINT = "fixedJoint";

	private const string TAG_HINGE_JOINT = "hingeJoint";

	private const string TAG_TWO_POINT = "twoPoint";

	private const string TAG_MOTOR_BLOCK = "motorBlock";

	private const string ATTR_MOTOR_BLOCK_ID = "block_id";

	private const string ATTR_MOTOR_BODY_INDEX = "body_idx";

	private const string ATTR_MOTOR_HINGE_INDEX = "hinge_idx";

	private const string TAG_MOTOR_JOINT = "motorJoint";

	private const string ATTR_FORWARD_KEY = "f_key";

	private const string ATTR_BACKWARD_KEY = "b_key";

	private const string ATTR_BRAKE_KEY = "br_key";

	private const string ATTR_CLOCKWISE_ROTATION = "clockwise";

	private const string TAG_STEERABLE_JOINT = "steerableJoint";

	private const string ATTR_TOGGLE_TYPE = "toggle_type";

	private const string ATTR_FORWARD_TARGET = "f_target";

	private const string ATTR_BACKWARD_TARGET = "b_target";

	private const string ATTR_ANGLE_OFFSET = "a_offset";

	private const string TAG_STEPPER_JOINT = "stepperJoint";

	private const string ATTR_DEGREES_PER_SECOND = "d_p_sec";

	private const string TAG_DEFAULT_KEY = "defaultKey";

	private const string ATTR_KEY_NAME = "name";

	private const string ATTR_KEY_VALUE = "value";

	private const string ATTR_AXIS_VALUE = "axis";

	private const string TAG_OVERRIDABLE_PROPERTY = "ovProp";

	private const string ATTR_OP_KEY = "key";

	private const string ATTR_OP_VALUE = "value";

	private const string TAG_LOGIC_SYSTEM = "logicSystem";

	private const string TAG_LOGIC = "logic";

	private const string ATTR_ID = "id";

	private const string ATTR_NAME = "name";

	private const string ATTR_DESCRIPTION = "description";

	private const string ATTR_BLOCK_ID = "id";

	private const string ATTR_SCHEMATIC_ID = "schematic_id";

	private const string ATTR_POSITION = "position";

	private const string ATTR_ROTATION = "rotation";

	private const string ATTR_AXIS_DIRECTION = "axis_direction";

	private const string ATTR_CONNECTED_BLOCK_ID = "connected_block_id";

	private const string ATTR_CONNECTED_BODY_INDEX = "connected_body_idx";

	private const string ATTR_ANCHOR_POSITION = "anchor";

	private const string ATTR_FULL_JOINT = "full";

	private const string TAG_KEYSGROUPS = "keysGroups";

	private const string TAG_KEYSGROUP = "keyGroup";

	private const string ATTR_KEY_ID = "key_id";

	private const string ATTR_KEY_LABEL = "label";

	public static CreationModel BuildCreationModelFromSchematic(Schematic schematic)
	{
		CreationModel creationModel = new CreationModel(schematic.Id, schematic.Name, schematic.Description, isOriginatedFromSchematic: true);
		BlockModel blockModel = new BlockModel(schematic);
		foreach (BodySchematic allBodySchematic in schematic.GetAllBodySchematics())
		{
			BlockBodyModel blockBodyModel = new BlockBodyModel
			{
				BodySchematic = allBodySchematic
			};
			foreach (ComponentSchematic value in allBodySchematic.ComponentSchematics.Values)
			{
				blockBodyModel.AddComponentModel(BuildComponentModel(value));
			}
			blockModel.AddBlockBodyModel(blockBodyModel);
		}
		creationModel.AddBlockModel(blockModel);
		BodySchematic bodySchematic = schematic.GetBodySchematic(0);
		creationModel.DefaultConnectors.AddRange(bodySchematic.DefaultConnectors);
		schematic.OnInfosUpdatedEvent += delegate
		{
			creationModel.Name = schematic.Name;
			creationModel.Description = schematic.Description;
		};
		return creationModel;
	}

	[Obsolete("Esse método esta desatualizado e não é mais usado")]
	public static ICollection<BlockModel> BuildBlockModels(BlockView[] blockViews)
	{
		Dictionary<int, BlockModel> dictionary = new Dictionary<int, BlockModel>();
		BlockView[] array = blockViews;
		foreach (BlockView obj in array)
		{
			BlockModel blockModel = AddBlockModel(obj);
			foreach (BlockBodyView allBlockBodyView in obj.GetAllBlockBodyViews())
			{
				BlockBodyModel blockBodyModel = AddBlockBodyModel(allBlockBodyView);
				blockModel.AddBlockBodyModel(blockBodyModel);
			}
			dictionary.Add(blockModel.Id, blockModel);
		}
		array = blockViews;
		foreach (BlockView blockView in array)
		{
			BlockModel blockModel2 = dictionary[blockView.Id];
			foreach (BlockBodyView allBlockBodyView2 in blockView.GetAllBlockBodyViews())
			{
				_ = allBlockBodyView2.gameObject;
				BlockBodyModel blockBodyModel2 = blockModel2.GetBlockBodyModel(allBlockBodyView2.Index);
				foreach (FixedJointView allFixedJointView in allBlockBodyView2.GetAllFixedJointViews())
				{
					BlockBodyView connectedBlockBodyView = allFixedJointView.ConnectedBlockBodyView;
					BlockBodyModel blockBodyModel3 = dictionary[connectedBlockBodyView.ParentBlockView.Id].GetBlockBodyModel(connectedBlockBodyView.Index);
					AddFixedJointModel(blockBodyModel2, blockBodyModel3);
				}
				foreach (HingeJointView allHingeJointView in allBlockBodyView2.GetAllHingeJointViews())
				{
					HingeJoint hingeJoint = allHingeJointView.HingeJoint;
					BlockBodyView component = hingeJoint.connectedBody.GetComponent<BlockBodyView>();
					BlockBodyModel blockBodyModel4 = dictionary[component.ParentBlockView.Id].GetBlockBodyModel(component.Index);
					HingeJointModel hingeJointModel = AddHingeJointModel(blockBodyModel2, blockBodyModel4, hingeJoint.anchor, hingeJoint.axis);
					AddMotorBlockBodyModel(dictionary, allHingeJointView, hingeJointModel);
					AddMotorJointModel(allHingeJointView, hingeJointModel);
					AddSteerableJointModel(allHingeJointView, hingeJointModel);
				}
				AddTwoPointBlockModel(allBlockBodyView2.gameObject, blockBodyModel2);
			}
		}
		array = blockViews;
		foreach (BlockView blockView2 in array)
		{
			BlockModel blockModel3 = dictionary[blockView2.Id];
			foreach (BlockBodyView allBlockBodyView3 in blockView2.GetAllBlockBodyViews())
			{
				BlockBodyModel blockBodyModel5 = blockModel3.GetBlockBodyModel(allBlockBodyView3.Index);
				BaseComponentView[] components = allBlockBodyView3.GetComponents<BaseComponentView>();
				foreach (BaseComponentView component2 in components)
				{
					AddComponentModel(dictionary, blockBodyModel5, component2);
				}
				foreach (LogicIO allLogicIO in allBlockBodyView3.GetAllLogicIOs())
				{
					if (allLogicIO.Direction == LogicIODirection.Input)
					{
						blockBodyModel5.GetDefaultKeyIO(allLogicIO.Name).KeyValue = allLogicIO.DefaultKey;
					}
				}
				foreach (string allKey in allBlockBodyView3.OverridableProperties.GetAllKeys())
				{
					blockBodyModel5.SetOverridableProperty(allKey, allBlockBodyView3.OverridableProperties.GetProperty(allKey));
				}
			}
		}
		return dictionary.Values;
	}

	private static BlockModel AddBlockModel(BlockView blockView)
	{
		GameObject gameObject = blockView.gameObject;
		return new BlockModel(blockView.Schematic)
		{
			Id = blockView.Id,
			Position = gameObject.transform.localPosition,
			Rotation = gameObject.transform.localRotation
		};
	}

	private static BlockBodyModel AddBlockBodyModel(BlockBodyView blockBodyView)
	{
		return new BlockBodyModel
		{
			Index = blockBodyView.Index,
			BodySchematic = blockBodyView.BodySchematic
		};
	}

	private static void AddFixedJointModel(BlockBodyModel hostBlockBodyModel, BlockBodyModel connectedBlockBodyModel)
	{
		FixedJointModel fixedJointModel = new FixedJointModel
		{
			ConnectedBlockBodyModel = connectedBlockBodyModel
		};
		hostBlockBodyModel.AddFixedJointModel(fixedJointModel);
	}

	private static HingeJointModel AddHingeJointModel(BlockBodyModel hostBlockBodyModel, BlockBodyModel connectedBlockBodyModel, Vector3 position, Vector3 axisDirection)
	{
		HingeJointModel hingeJointModel = new HingeJointModel
		{
			ConnectedBlockBodyModel = connectedBlockBodyModel,
			Position = position,
			AxisDirection = axisDirection
		};
		hostBlockBodyModel.AddHingeJointModel(hingeJointModel);
		return hingeJointModel;
	}

	private static void AddMotorBlockBodyModel(Dictionary<int, BlockModel> blockModelMap, HingeJointView hingeJointView, HingeJointModel hingeJointModel)
	{
		if (!(hingeJointView.MotorBodyBlockView == null))
		{
			BlockBodyView motorBodyBlockView = hingeJointView.MotorBodyBlockView;
			BlockBodyModel blockBodyModel = blockModelMap[motorBodyBlockView.ParentBlockView.Id].GetBlockBodyModel(motorBodyBlockView.Index);
			hingeJointModel.MotorBlockBodyModel = blockBodyModel;
		}
	}

	private static void AddMotorJointModel(HingeJointView hingeJointView, HingeJointModel hingeJointModel)
	{
		MotorJointView motorJointView = hingeJointView.MotorJointView;
		if (motorJointView != null)
		{
			MotorJointModel motorJointModel = new MotorJointModel(hingeJointModel)
			{
				IsClockwiseRotation = motorJointView.IsClockwiseRotation
			};
			hingeJointModel.SetMotorJointModel(motorJointModel);
		}
	}

	private static void AddSteerableJointModel(HingeJointView hingeJointView, HingeJointModel hingeJointModel)
	{
		SteerableJointView steerableJointView = hingeJointView.SteerableJointView;
		if (steerableJointView != null)
		{
			SteerableJointModel steerableJointModel = new SteerableJointModel(hingeJointModel)
			{
				ForwardTarget = steerableJointView.forwardTarget,
				BackwardTarget = steerableJointView.backwardTarget
			};
			hingeJointModel.SetSteerableJointModel(steerableJointModel);
		}
	}

	private static void AddTwoPointBlockModel(GameObject blockBodyObject, BlockBodyModel blockBodyModel)
	{
		TwoPointBlock component = blockBodyObject.GetComponent<TwoPointBlock>();
		if (!(component == null))
		{
			TwoPointBlockModel twoPointBlockModel = new TwoPointBlockModel
			{
				ParentBlockBodyModel = blockBodyModel,
				EndPointPosition = component.endPointPosition,
				EndPointRotation = component.endPointRotation
			};
			blockBodyModel.TwoPointBlockModel = twoPointBlockModel;
		}
	}

	private static void AddComponentModel(Dictionary<int, BlockModel> blockModelMap, BlockBodyModel blockBodyModel, BaseComponentView component)
	{
		ComponentModel componentModel = ComponentModel.Instantiate(blockBodyModel.BodySchematic.ComponentSchematics[component.GetComponentName()]);
		if (componentModel.Type == ComponentType.Motor && component is MotorView)
		{
			MotorView obj = component as MotorView;
			MotorModel motorModel = new MotorModel();
			foreach (HingeJointView allHingeJointView in obj.GetAllHingeJointViews())
			{
				int id = allHingeJointView.ParentBlockBodyView.ParentBlockView.Id;
				int index = allHingeJointView.ParentBlockBodyView.Index;
				int index2 = allHingeJointView.Index;
				motorModel.AddHingeJointModel(blockModelMap[id].GetBlockBodyModel(index).GetHingeJointModel(index2));
			}
			componentModel.InternalProperties.Add(MotorModel.Name, motorModel);
		}
		blockBodyModel.AddComponentModel(componentModel);
	}

	private static ComponentModel BuildComponentModel(ComponentSchematic componentSchematic)
	{
		ComponentModel componentModel = ComponentModel.Instantiate(componentSchematic);
		if (componentModel.Type == ComponentType.Motor)
		{
			componentModel.InternalProperties.Add(MotorModel.Name, new MotorModel());
		}
		return componentModel;
	}

	public static XElement SaveXml(CreationModel creationModel, string path = null, bool isFileEncrypted = false)
	{
		creationModel.ResetBlocksIds();
		XElement xElement = new XElement("creation");
		xElement.Add(new XAttribute("id", creationModel.Id));
		xElement.Add(new XAttribute("name", creationModel.Name));
		xElement.Add(new XAttribute("description", creationModel.Description));
		xElement.Add(new XAttribute("position", creationModel.Position.PrintFullValues()));
		xElement.Add(new XAttribute("rotation", creationModel.Rotation.PrintFullValues()));
		XElement xElement2 = new XElement("blocks");
		foreach (BlockModel item in creationModel.GetAllBlockModel())
		{
			XElement xElement3 = new XElement("block");
			xElement3.Add(new XAttribute("id", item.Id));
			xElement3.Add(new XAttribute("schematic_id", item.Schematic.Id));
			xElement3.Add(new XAttribute("position", item.Position.PrintFullValues()));
			xElement3.Add(new XAttribute("rotation", item.Rotation.PrintFullValues()));
			foreach (BlockBodyModel allBlockBodyModel in item.GetAllBlockBodyModels())
			{
				XElement xElement4 = new XElement("body");
				foreach (FixedJointModel item2 in allBlockBodyModel.GetAllFixedJointModel())
				{
					int id = item2.ConnectedBlockBodyModel.ParentBlockModel.Id;
					int index = item2.ConnectedBlockBodyModel.Index;
					XElement xElement5 = new XElement("fixedJoint");
					xElement5.Add(new XAttribute("connected_block_id", id));
					xElement5.Add(new XAttribute("connected_body_idx", index));
					xElement5.Add(new XAttribute("full", item2.IsFullJoint));
					xElement5.Add(new XAttribute("position", item2.Position.PrintFullValues()));
					xElement5.Add(new XAttribute("axis_direction", item2.AxisDirection.PrintFullValues()));
					xElement4.Add(xElement5);
				}
				foreach (HingeJointModel item3 in allBlockBodyModel.GetAllHingeJointModel())
				{
					int id2 = item3.ConnectedBlockBodyModel.ParentBlockModel.Id;
					int index2 = item3.ConnectedBlockBodyModel.Index;
					XElement xElement6 = new XElement("hingeJoint");
					xElement6.Add(new XAttribute("connected_block_id", id2));
					xElement6.Add(new XAttribute("connected_body_idx", index2));
					xElement6.Add(new XAttribute("position", item3.Position.PrintFullValues()));
					xElement6.Add(new XAttribute("axis_direction", item3.AxisDirection.PrintFullValues()));
					xElement6.Add(new XAttribute("anchor", item3.IsThisAnchorPoint));
					if (item3.MotorJointModel != null)
					{
						XElement xElement7 = new XElement("motorJoint");
						xElement7.Add(new XAttribute("clockwise", item3.MotorJointModel.IsClockwiseRotation));
						xElement6.Add(xElement7);
					}
					if (item3.SteerableJointModel != null)
					{
						XElement xElement8 = new XElement("steerableJoint");
						xElement8.Add(new XAttribute("toggle_type", item3.SteerableJointModel.IsToggleActivationType));
						xElement8.Add(new XAttribute("f_target", item3.SteerableJointModel.ForwardTarget));
						xElement8.Add(new XAttribute("b_target", item3.SteerableJointModel.BackwardTarget));
						xElement8.Add(new XAttribute("a_offset", item3.SteerableJointModel.AngleOffset));
						xElement6.Add(xElement8);
					}
					if (item3.StepperJointModel != null)
					{
						XElement xElement9 = new XElement("stepperJoint");
						xElement9.Add(new XAttribute("d_p_sec", item3.StepperJointModel.DegreesPerSecond));
						xElement9.Add(new XAttribute("clockwise", item3.StepperJointModel.IsClockwiseRotation));
						xElement6.Add(xElement9);
					}
					xElement4.Add(xElement6);
				}
				if (allBlockBodyModel.TwoPointBlockModel != null)
				{
					XElement xElement10 = new XElement("twoPoint");
					xElement10.Add(new XAttribute("position", allBlockBodyModel.TwoPointBlockModel.EndPointPosition.PrintFullValues()));
					xElement10.Add(new XAttribute("rotation", allBlockBodyModel.TwoPointBlockModel.EndPointRotation.PrintFullValues()));
					xElement4.Add(xElement10);
				}
				foreach (DefaultKeyIO allDefaultKeyIO in allBlockBodyModel.GetAllDefaultKeyIOs())
				{
					XElement xElement11 = new XElement("defaultKey");
					xElement11.Add(new XAttribute("name", allDefaultKeyIO.Name));
					xElement11.Add(new XAttribute("value", allDefaultKeyIO.KeyValue));
					xElement11.Add(new XAttribute("axis", allDefaultKeyIO.AxisValue));
					xElement4.Add(xElement11);
				}
				foreach (OverridablePropertyModel allOverridableProperty in allBlockBodyModel.GetAllOverridableProperties())
				{
					XElement xElement12 = new XElement("ovProp");
					xElement12.Add(new XAttribute("key", allOverridableProperty.Key));
					xElement12.Add(new XAttribute("value", allOverridableProperty.Value));
					xElement4.Add(xElement12);
				}
				foreach (ComponentModel item4 in allBlockBodyModel.GetAllComponentModel())
				{
					if (item4.Type != ComponentType.Motor)
					{
						continue;
					}
					foreach (HingeJointModel allHingeJointModel in (item4.InternalProperties[MotorModel.Name] as MotorModel).GetAllHingeJointModels())
					{
						XElement xElement13 = new XElement("motorBlock");
						xElement13.Add(new XAttribute("block_id", allHingeJointModel.ParentBlockBodyModel.ParentBlockModel.Id));
						xElement13.Add(new XAttribute("body_idx", allHingeJointModel.ParentBlockBodyModel.Index));
						xElement13.Add(new XAttribute("hinge_idx", allHingeJointModel.Index));
						xElement4.Add(xElement13);
					}
				}
				xElement3.Add(xElement4);
			}
			xElement2.Add(xElement3);
		}
		xElement.Add(xElement2);
		XElement content = LogicSystemModelBuilder.SaveXml(creationModel.LogicSystemModel);
		xElement.Add(content);
		XElement xElement14 = new XElement("keysGroups");
		string[] allKeysGroupLabelKeys = creationModel.GetAllKeysGroupLabelKeys();
		foreach (string text in allKeysGroupLabelKeys)
		{
			string keysGroupLabel = creationModel.GetKeysGroupLabel(text);
			XElement xElement15 = new XElement("keyGroup");
			xElement15.Add(new XAttribute("key_id", text));
			xElement15.Add(new XAttribute("label", keysGroupLabel));
			xElement14.Add(xElement15);
		}
		xElement.Add(xElement14);
		if (path != null)
		{
			XDocument xDocument = new XDocument();
			xDocument.Add(xElement);
			if (isFileEncrypted)
			{
				string contents = StringCipher.Encrypt(xDocument.ToString(), Util.PassPhrase);
				File.WriteAllText(path, contents);
			}
			else
			{
				xDocument.Save(path);
			}
		}
		return xElement;
	}

	public static CreationModel LoadXml(string path, SchematicCollection schematicCollection, bool isFileEncrypted)
	{
		XDocument xDocument = ((!isFileEncrypted) ? XDocument.Load(path) : XDocument.Parse(StringCipher.Decrypt(File.ReadAllText(path), Util.PassPhrase)));
		CreationModel creationModel = LoadXml(xDocument.Element("creation"), schematicCollection);
		creationModel.FilePath = path;
		return creationModel;
	}

	public static CreationModel LoadXml(XElement xCreation, SchematicCollection schematicCollection)
	{
		string value = xCreation.Attribute("id").Value;
		string value2 = xCreation.Attribute("name").Value;
		string value3 = xCreation.Attribute("description").Value;
		CreationModel creationModel = new CreationModel(value, value2, value3);
		if (xCreation.Attribute("position") != null && xCreation.Attribute("rotation") != null)
		{
			creationModel.Position = Util.Vector3Parser(xCreation.Attribute("position").Value);
			creationModel.Rotation = Util.QuaternionParser(xCreation.Attribute("rotation").Value);
		}
		List<int> list = new List<int>();
		XElement xElement = xCreation.Element("blocks");
		foreach (XElement item in xElement.Elements())
		{
			int attributeAsInt = item.GetAttributeAsInt("id");
			if (list.Contains(attributeAsInt))
			{
				Debug.LogError($"Trying add block with the same ID! [{attributeAsInt}]");
				continue;
			}
			list.Add(attributeAsInt);
			BlockModel blockModel = new BlockModel(schematicCollection.GetSchematic(item.Attribute("schematic_id").Value))
			{
				Id = item.GetAttributeAsInt("id"),
				Position = Util.Vector3Parser(item.Attribute("position").Value),
				Rotation = Util.QuaternionParser(item.Attribute("rotation").Value)
			};
			foreach (XElement item2 in item.Elements("body"))
			{
				_ = item2;
				BlockBodyModel blockBodyModel = new BlockBodyModel();
				blockModel.AddBlockBodyModel(blockBodyModel);
			}
			creationModel.AddBlockModel(blockModel);
		}
		list.Clear();
		foreach (XElement item3 in xElement.Elements())
		{
			int attributeAsInt2 = item3.GetAttributeAsInt("id");
			BlockModel blockModel2 = creationModel.GetBlockModel(attributeAsInt2);
			if (blockModel2 == null || list.Contains(attributeAsInt2))
			{
				continue;
			}
			list.Add(attributeAsInt2);
			int num = 0;
			foreach (XElement item4 in item3.Elements("body"))
			{
				BlockBodyModel blockBodyModel2 = blockModel2.GetBlockBodyModel(num);
				foreach (XElement item5 in item4.Elements("fixedJoint"))
				{
					int attributeAsInt3 = item5.GetAttributeAsInt("connected_block_id");
					int attributeAsInt4 = item5.GetAttributeAsInt("connected_body_idx");
					BlockBodyModel blockBodyModel3 = creationModel.GetBlockBodyModel(attributeAsInt3, attributeAsInt4);
					if (blockBodyModel3 == null)
					{
						Debug.LogError($"Fixed Joint: Not found the connectedBlockBodyModel! [{attributeAsInt3}, {attributeAsInt4}]");
						continue;
					}
					FixedJointModel fixedJointModel = creationModel.FixedConnectTwoBlocks(blockBodyModel2, blockBodyModel3);
					fixedJointModel.IsFullJoint = item5.GetAttributeAsBool("full");
					if (fixedJointModel.IsFullJoint)
					{
						fixedJointModel.Position = Util.Vector3Parser(item5.GetAttributeAsString("position"));
						fixedJointModel.AxisDirection = Util.Vector3Parser(item5.GetAttributeAsString("axis_direction"));
					}
				}
				foreach (XElement item6 in item4.Elements("hingeJoint"))
				{
					int attributeAsInt5 = item6.GetAttributeAsInt("connected_block_id");
					int attributeAsInt6 = item6.GetAttributeAsInt("connected_body_idx");
					BlockBodyModel blockBodyModel4 = creationModel.GetBlockBodyModel(attributeAsInt5, attributeAsInt6);
					if (blockBodyModel4 == null)
					{
						Debug.LogError($"Hinge Joint: Not found the connectedBlockBodyModel! [{attributeAsInt5}, {attributeAsInt6}]");
						continue;
					}
					Vector3 position = Util.Vector3Parser(item6.Attribute("position").Value);
					Vector3 axisDirection = Util.Vector3Parser(item6.Attribute("axis_direction").Value);
					HingeJointModel hingeJointModel = creationModel.HingeConnectTwoBlocks(blockBodyModel2, blockBodyModel4, position, axisDirection);
					hingeJointModel.IsThisAnchorPoint = item6.GetAttributeAsBool("anchor");
					XElement xElement2 = item6.Element("motorJoint");
					if (xElement2 != null)
					{
						MotorJointModel motorJointModel = new MotorJointModel(hingeJointModel)
						{
							IsClockwiseRotation = bool.Parse(xElement2.Attribute("clockwise").Value)
						};
						hingeJointModel.SetMotorJointModel(motorJointModel);
					}
					XElement xElement3 = item6.Element("steerableJoint");
					if (xElement3 != null)
					{
						SteerableJointModel steerableJointModel = new SteerableJointModel(hingeJointModel)
						{
							IsToggleActivationType = xElement3.GetAttributeAsBool("toggle_type"),
							ForwardTarget = xElement3.GetAttributeAsFloat("f_target"),
							BackwardTarget = xElement3.GetAttributeAsFloat("b_target"),
							AngleOffset = xElement3.GetAttributeAsFloat("a_offset")
						};
						hingeJointModel.SetSteerableJointModel(steerableJointModel);
					}
					XElement xElement4 = item6.Element("stepperJoint");
					if (xElement4 != null)
					{
						StepperJointModel stepperJointModel = new StepperJointModel(hingeJointModel)
						{
							DegreesPerSecond = xElement4.GetAttributeAsFloat("d_p_sec"),
							IsClockwiseRotation = xElement4.GetAttributeAsBool("clockwise")
						};
						hingeJointModel.SetStepperJointModel(stepperJointModel);
					}
				}
				XElement xElement5 = item4.Element("twoPoint");
				if (xElement5 != null)
				{
					TwoPointBlockModel twoPointBlockModel = new TwoPointBlockModel
					{
						ParentBlockBodyModel = blockBodyModel2,
						EndPointPosition = Util.Vector3Parser(xElement5.Attribute("position").Value),
						EndPointRotation = Util.QuaternionParser(xElement5.Attribute("rotation").Value)
					};
					blockBodyModel2.TwoPointBlockModel = twoPointBlockModel;
				}
				num++;
			}
		}
		list.Clear();
		foreach (XElement item7 in xElement.Elements())
		{
			int attributeAsInt7 = item7.GetAttributeAsInt("id");
			BlockModel blockModel3 = creationModel.GetBlockModel(attributeAsInt7);
			if (blockModel3 == null || list.Contains(attributeAsInt7))
			{
				continue;
			}
			list.Add(attributeAsInt7);
			int num2 = 0;
			foreach (XElement item8 in item7.Elements("body"))
			{
				BlockBodyModel blockBodyModel5 = blockModel3.GetBlockBodyModel(num2);
				foreach (ComponentSchematic value4 in blockBodyModel5.BodySchematic.ComponentSchematics.Values)
				{
					ComponentModel componentModel = BuildComponentModel(value4);
					if (componentModel.Type == ComponentType.Motor)
					{
						MotorModel motorModel = componentModel.InternalProperties[MotorModel.Name] as MotorModel;
						foreach (XElement item9 in item8.Elements("motorBlock"))
						{
							attributeAsInt7 = item9.GetAttributeAsInt("block_id");
							int attributeAsInt8 = item9.GetAttributeAsInt("body_idx");
							int attributeAsInt9 = item9.GetAttributeAsInt("hinge_idx");
							HingeJointModel hingeJointModel2 = creationModel.GetBlockModel(attributeAsInt7).GetBlockBodyModel(attributeAsInt8).GetHingeJointModel(attributeAsInt9);
							motorModel.AddHingeJointModel(hingeJointModel2);
							hingeJointModel2.MotorBlockBodyModel = blockBodyModel5;
						}
					}
					blockBodyModel5.AddComponentModel(componentModel);
				}
				foreach (XElement item10 in item8.Elements("defaultKey"))
				{
					string attributeAsString = item10.GetAttributeAsString("name");
					KeyCode attributeAsKeyCode = item10.GetAttributeAsKeyCode("value");
					AxisCode attributeAsAxisCode = item10.GetAttributeAsAxisCode("axis");
					blockBodyModel5.GetDefaultKeyIO(attributeAsString).KeyValue = attributeAsKeyCode;
					blockBodyModel5.GetDefaultKeyIO(attributeAsString).AxisValue = attributeAsAxisCode;
				}
				foreach (XElement item11 in item8.Elements("ovProp"))
				{
					string attributeAsString2 = item11.GetAttributeAsString("key");
					string attributeAsString3 = item11.GetAttributeAsString("value");
					blockBodyModel5.GetOverridableProperty(attributeAsString2).Value = attributeAsString3;
				}
				num2++;
			}
		}
		XElement xLogicSystemModel = xCreation.Element("logicSystem");
		creationModel.LogicSystemModel = LogicSystemModelBuilder.LoadXml(xLogicSystemModel);
		XElement xElement6 = xCreation.Element("keysGroups");
		if (xElement6 != null)
		{
			foreach (XElement item12 in xElement6.Elements("keyGroup"))
			{
				string attributeAsString4 = item12.GetAttributeAsString("key_id");
				string attributeAsString5 = item12.GetAttributeAsString("label");
				creationModel.AddKeysGroupLabel(attributeAsString4, attributeAsString5);
			}
		}
		return creationModel;
	}
}
