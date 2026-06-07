using SettingScripts;
using UIScripts.SettingHandles;
using UIScripts.SettingHandles.References;
using UnityEngine;

namespace UIScripts
{
	public class ConnectionEditPanel : MonoBehaviour
	{
		private ConnectionEditor connection;

		public RectTransform rt;

		[SerializeField]
		private SettingSliderReference weightSliderRef;

		[SerializeField]
		private SettingToggleReference enabledToggleRef;

		private FloatSettingSlider weightSlider;

		private SettingToggle enabledToggle;

		private FloatSetting weight = new FloatSetting
		{
			Name = "Weight",
			HelperText = "The connection's strength is used when propagating information.\nIt's multiplied to the input node's value before propagating it to the output's node activation.",
			DefaultValue = 0f,
			val = 0f,
			minValue = -10f,
			maxValue = 10f,
			canGoOutOfBounds = true,
			SI = false,
			precision = 2
		};

		private BoolSetting isEnabled = new BoolSetting
		{
			Name = "Enabled",
			HelperText = "A disabled connection will not propagate its input.\nThe use is that re-enabling it is a likelier mutation then re-evolving the connection completely.",
			DefaultValue = true,
			val = true
		};

		public void Init()
		{
			weightSlider = new FloatSettingSlider(weight);
			weightSlider.InitUIElement(weightSliderRef);
			enabledToggle = new SettingToggle(isEnabled);
			enabledToggle.InitUIElement(enabledToggleRef);
			weight.OnValueChange.AddListener(EditWeight);
			isEnabled.OnValueChange.AddListener(EditEnabled);
		}

		public void SelectConnection(ConnectionEditor con, Vector2 pos, Vector2 anchor)
		{
			if (connection != null)
			{
				connection.SetHighlight(val: false);
			}
			connection = null;
			weight.SetValue(con.weight);
			isEnabled.SetValue(con.isEnabled);
			connection = con;
			connection.SetHighlight(val: true);
			rt.pivot = anchor;
			rt.anchoredPosition = pos;
			base.gameObject.SetActive(value: true);
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Delete))
			{
				RemoveConnection();
			}
		}

		private void EditWeight(float val)
		{
			if (!(connection == null))
			{
				connection.EditWeight(val);
			}
		}

		private void EditEnabled(bool val)
		{
			if (!(connection == null))
			{
				connection.EditEnabled(val);
			}
		}

		public void SplitWithNode(bool remainIngoing)
		{
			if (!(connection == null))
			{
				BibiteBrainEditor.instance.SplitConnectionInNewNode(connection, remainIngoing);
			}
		}

		public void RemoveConnection()
		{
			BibiteBrainEditor.instance.DeleteConnection(connection);
		}

		public void Hide()
		{
			if (connection != null)
			{
				connection.SetHighlight(val: false);
			}
			connection = null;
			base.gameObject.SetActive(value: false);
		}
	}
}
