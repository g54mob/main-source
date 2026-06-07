using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi.Craft.Program.Craft;
using UnityEngine;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class SetCraftInputInstruction : ProgramInstruction
	{
		private class Input
		{
			public string DisplayName { get; set; }

			public ListItemInfoType ListItemInfoType { get; set; }

			public Action<ICraftInputs, float> Setter { get; set; }

			public string Tooltip { get; set; }

			public string XmlName { get; set; }

			public Input(string displayName, string xmlName, Action<ICraftInputs, float> setter)
			{
				DisplayName = displayName;
				XmlName = xmlName;
				Setter = setter;
				Tooltip = $"Sets the craft's {displayName} input.";
				ListItemInfoType = ListItemInfoType.Number;
			}
		}

		private static List<Input> _inputs;

		[ProgramNodeProperty]
		private string _input;

		private Input _selectedInput;

		static SetCraftInputInstruction()
		{
			_inputs = new List<Input>();
			AddInput("Roll", "roll", delegate(ICraftInputs c, float x)
			{
				c.Roll = Mathf.Clamp(x, -1f, 1f);
			});
			AddInput("Pitch", "pitch", delegate(ICraftInputs c, float x)
			{
				c.Pitch = Mathf.Clamp(x, -1f, 1f);
			});
			AddInput("Yaw", "yaw", delegate(ICraftInputs c, float x)
			{
				c.Yaw = Mathf.Clamp(x, -1f, 1f);
			});
			AddInput("Throttle", "throttle", delegate(ICraftInputs c, float x)
			{
				c.Throttle = Mathf.Clamp01(x);
			});
			AddInput("Brake", "brake", delegate(ICraftInputs c, float x)
			{
				c.Brake = Mathf.Clamp01(x);
			});
			AddInput("Slider 1", "slider1", delegate(ICraftInputs c, float x)
			{
				c.Slider1 = Mathf.Clamp(x, -1f, 1f);
			});
			AddInput("Slider 2", "slider2", delegate(ICraftInputs c, float x)
			{
				c.Slider2 = Mathf.Clamp(x, -1f, 1f);
			});
			AddInput("Slider 3", "slider3", delegate(ICraftInputs c, float x)
			{
				c.Slider3 = Mathf.Clamp(x, -1f, 1f);
			});
			AddInput("Slider 4", "slider4", delegate(ICraftInputs c, float x)
			{
				c.Slider4 = Mathf.Clamp(x, -1f, 1f);
			});
			AddInput("Translate Forward", "translateForward", delegate(ICraftInputs c, float x)
			{
				c.TranslateForward = Mathf.Clamp(x, -1f, 1f);
			});
			AddInput("Translate Right", "translateRight", delegate(ICraftInputs c, float x)
			{
				c.TranslateRight = Mathf.Clamp(x, -1f, 1f);
			});
			AddInput("Translate Up", "translateUp", delegate(ICraftInputs c, float x)
			{
				c.TranslateUp = Mathf.Clamp(x, -1f, 1f);
			});
			AddInput("Translation Mode", "translationMode", delegate(ICraftInputs c, float x)
			{
				c.TranslationMode = x != 0f;
			}).Tooltip = "Zero disables and non-zero enables Translation Mode.";
		}

		public SetCraftInputInstruction()
		{
			_input = _inputs[0].XmlName;
		}

		public override ProgramInstruction Execute(IThreadContext context)
		{
			if (_selectedInput != null)
			{
				float arg = (float)GetExpression(0).Evaluate(context).NumberValue;
				_selectedInput.Setter(context.Craft.Inputs, arg);
			}
			return base.Execute(context);
		}

		public override List<ListItemInfo> GetListItems(string listId)
		{
			List<ListItemInfo> list = new List<ListItemInfo>();
			foreach (Input input in _inputs)
			{
				list.Add(new ListItemInfo(input.XmlName, input.DisplayName, input.Tooltip, input.ListItemInfoType));
			}
			return list;
		}

		public override string GetListValue(string listId)
		{
			return _selectedInput.XmlName;
		}

		public override void OnDeserialized(XElement xml)
		{
			base.OnDeserialized(xml);
			_selectedInput = _inputs.Where((Input x) => x.XmlName == _input).FirstOrDefault();
		}

		public override void SetListValue(string listId, string value)
		{
			_selectedInput = _inputs.Where((Input x) => x.XmlName == value).FirstOrDefault();
			_input = _selectedInput.XmlName;
		}

		private static Input AddInput(string displayName, string xmlName, Action<ICraftInputs, float> setter)
		{
			Input input = new Input(displayName, xmlName, setter);
			_inputs.Add(input);
			return input;
		}
	}
}
