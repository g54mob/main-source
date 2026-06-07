using System;

namespace SettingScripts
{
	[Serializable]
	public class ExpandedBrainParameters
	{
		public static ExpandedBrainParameters Instance = new ExpandedBrainParameters();

		public FloatSetting attractionToCenter = new FloatSetting
		{
			Name = "Gravity to Center",
			HelperText = "How attracted each node is to the center of the panel.  A higher value will increase the force at which nodes are pulled to the center",
			DefaultValue = 90f,
			val = 90f,
			minValue = 10f,
			maxValue = 150f,
			precision = 2,
			prefix = "",
			units = ""
		};

		public FloatSetting synapseAttraction = new FloatSetting
		{
			Name = "Synaptic Attraction",
			HelperText = "How strongly nodes are pulled toward each other if they are connected by a synaptic connection.",
			DefaultValue = 0.3f,
			val = 0.3f,
			minValue = 0.01f,
			maxValue = 2f,
			precision = 2,
			prefix = "",
			units = ""
		};

		public FloatSetting repulsionFromCenter = new FloatSetting
		{
			Name = "Repulsion from Center",
			HelperText = "How strongly input and output nodes are repulsed from the center.  Since this does not apply to hidden nodes this is a good tool to create separation between inner and outer nodes",
			DefaultValue = 1500f,
			val = 1500f,
			minValue = 1f,
			maxValue = 15000f,
			precision = 1,
			prefix = "",
			units = ""
		};

		public FloatSetting neuronRepulsion = new FloatSetting
		{
			Name = "Neuron Repulsion",
			HelperText = "How strongly neurons repulse one another.",
			DefaultValue = 1000f,
			val = 1000f,
			minValue = 20f,
			maxValue = 5000f,
			precision = 1,
			prefix = "",
			units = ""
		};

		public FloatSetting circularFriction = new FloatSetting
		{
			Name = "Friction",
			HelperText = "This is the friction applied to all nodes as they move.  A higher friction will slow nodes down to a steady state faster but may cause the graph to settle for less optimized layouts",
			DefaultValue = 1f,
			val = 1f,
			minValue = 0.1f,
			maxValue = 5f,
			precision = 2,
			prefix = "",
			units = ""
		};

		public FloatSetting graphWidthStep = new FloatSetting
		{
			Name = "Graph Width",
			HelperText = "The distance between the column of input neurons and the column of output neurons",
			DefaultValue = 200f,
			val = 200f,
			minValue = 50f,
			maxValue = 1000f,
			precision = 1,
			prefix = "",
			units = ""
		};

		public FloatSetting graphHeightStep = new FloatSetting
		{
			Name = "Height Step",
			HelperText = "The step size between rows of input and output nodes",
			DefaultValue = 150f,
			val = 150f,
			minValue = 50f,
			maxValue = 500f,
			precision = 1,
			prefix = "",
			units = ""
		};

		public FloatSetting linearSynapseAttraction = new FloatSetting
		{
			Name = "Synaptic Attraction",
			HelperText = "How strongly nodes are pulled toward each other if they are connected by a synaptic connection.",
			DefaultValue = 1.5f,
			val = 1.5f,
			minValue = 0.1f,
			maxValue = 5f,
			precision = 2,
			prefix = "",
			units = ""
		};

		public FloatSetting linearNeuronRepulsion = new FloatSetting
		{
			Name = "Neuron Repulsion",
			HelperText = "How strongly neurons repulse one another.",
			DefaultValue = 1000f,
			val = 1000f,
			minValue = 20f,
			maxValue = 4000f,
			precision = 1,
			prefix = "",
			units = ""
		};

		public FloatSetting linearFriction = new FloatSetting
		{
			Name = "Friction",
			HelperText = "This is the friction applied to all nodes as they move.  A higher friction will slow nodes down to a steady state faster but may cause the graph to settle for less optimized layouts",
			DefaultValue = 1f,
			val = 1f,
			minValue = 0.1f,
			maxValue = 3f,
			precision = 2,
			prefix = "",
			units = ""
		};

		public FloatSetting switchingThreshold = new FloatSetting
		{
			Name = "Switching Threshold",
			HelperText = "The threshold of force required before input and output nodes will swap position.  Too low of a value will be unstable while too high will prevent the graph from finding an optimized layout",
			DefaultValue = 0.5f,
			val = 0.5f,
			minValue = -0.75f,
			maxValue = 2f,
			precision = 2,
			prefix = "",
			units = ""
		};
	}
}
