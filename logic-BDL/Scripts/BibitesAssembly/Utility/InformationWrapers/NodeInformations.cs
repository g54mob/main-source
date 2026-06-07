using System;
using System.Collections.Generic;
using System.Linq;
using SimulationScripts.BibiteScripts;

namespace Utility.InformationWrapers
{
	public static class NodeInformations
	{
		public static List<NodeInformation> inputs = new List<NodeInformation>
		{
			new NodeInformation
			{
				index = 0,
				name = "Energy Ratio",
				desc = "Outputs the current energy level",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 1,
				name = "Maturity",
				desc = "Outputs the bibite's current maturity (a value of 1.0 is reached when it can reproduce/lay eggs)",
				minOutput = 0f
			},
			new NodeInformation
			{
				index = 2,
				name = "Health Ratio",
				desc = "Outputs the bibite's current health (HP / maxHP)",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 3,
				name = "Fullness",
				desc = "Outputs how full the bibite's stomach is",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 4,
				name = "Speed",
				desc = "Outputs the bibite's current forward speed (normalized for its body length) (negative value means it's going backward to where it's facing"
			},
			new NodeInformation
			{
				index = 5,
				name = "Angular Speed",
				desc = "Outputs the bibite's current angular speed (normalized to full rotations per second) (positive values mean clockwise rotation, while negative means counterclockwise)"
			},
			new NodeInformation
			{
				index = 6,
				name = "Is Grabbing",
				desc = "Outputs whether the bibite is currently grabbing (1.0) or not (0.0) an object",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 7,
				name = "Received Attack Damages",
				desc = "Outputs the normalized pain of the bibite (attacked damages it received recently (decaying exponentially) / maxHP)\nAnalogous to a pain receptor",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 8,
				name = "Eggs Stored",
				desc = "Outputs the number of completed eggs stored in the bibite's egg organ",
				minOutput = 0f
			},
			new NodeInformation
			{
				index = 9,
				name = "Seen Bibites Closeness",
				desc = "Part of the bibite's vision system\nOutputs how close (normalize to its view radius) in its field of view the weighted average of bibites is",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 10,
				name = "Seen Bibites Angle",
				desc = "Part of the bibite's vision system\nOutputs the angle (normalized to its view angle) in its field of view the weighted average of bibites is \nNegative value are to the left, positive values to the right",
				minOutput = -1f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 11,
				name = "Seen Bibites Number",
				desc = "Part of the bibite's vision system\nOutputs the number of bibites in its field of view divided by 4",
				minOutput = 0f
			},
			new NodeInformation
			{
				index = 12,
				name = "Seen Plants Closeness",
				desc = "Part of the bibite's vision system\nOutputs how close (normalize to its view radius) in its field of view the weighted average of plant pellets is",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 13,
				name = "Seen Plants Angle",
				desc = "Part of the bibite's vision system\nOutputs the angle (normalized to its view angle) in its field of view the weighted average of plant pellets is \nNegative value are to the left, positive values to the right",
				minOutput = -1f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 14,
				name = "Seen Plants Number",
				desc = "Part of the bibite's vision system\nOutputs the number of plant pellets in its field of view divided by 4",
				minOutput = 0f
			},
			new NodeInformation
			{
				index = 15,
				name = "Seen Meats Closeness",
				desc = "Part of the bibite's vision system\nOutputs how close (normalize to its view radius) in its field of view the weighted average of meat pellets is",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 16,
				name = "Seen Meats Angle",
				desc = "Part of the bibite's vision system\nOutputs the angle (normalized to its view angle) in its field of view the weighted average of meat pellets is \nNegative value are to the left, positive values to the right",
				minOutput = -1f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 17,
				name = "Seen Meats Number",
				desc = "Part of the bibite's vision system\nOutputs the number of meat pellets in its field of view divided by 4",
				minOutput = 0f
			},
			new NodeInformation
			{
				index = 18,
				name = "Closest Bibite's Red Gene",
				desc = "Part of the bibite's vision system\nOutputs the Red Color Gene of the closest seen bibite",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 19,
				name = "Closest Bibite's Green Gene",
				desc = "Part of the bibite's vision system\nOutputs the Green Color Gene of the closest seen bibite",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 20,
				name = "Closest Bibite's Blue Gene",
				desc = "Part of the bibite's vision system\nOutputs the Blue Color Gene of the closest seen bibite",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 21,
				name = "Clock tick",
				desc = "Toggles between 0.0 and 1.0 periodically based on the bibite's clock rate gene (1s by default)",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 22,
				name = "Chronometer",
				desc = "Counts up the minutes since the last bibite's Internal Clock reset (an output node)",
				minOutput = 0f
			},
			new NodeInformation
			{
				index = 23,
				name = "Time Alive",
				desc = "Counts up the minutes since the bibite's birth",
				minOutput = 0f
			},
			new NodeInformation
			{
				index = 24,
				name = "Red Pheromones Strength",
				desc = "Outputs the perceived prevalence of red pheromones\nOutputs saturates for strong activations",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 27,
				name = "Red Pheromones Angle",
				desc = "Outputs the normalized angle to the perceived source of red pheromones\nNegative value are to the left, positive values to the right",
				minOutput = -1f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 30,
				name = "Red Pheromones Heading",
				desc = "Outputs the normalized angle to the perceived direction of red pheromones gradient (following the trail)\nNegative value are to the left, positive values to the right",
				minOutput = -1f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 25,
				name = "Green Pheromones Strength",
				desc = "Outputs the perceived prevalence of green pheromones\nOutputs saturates for strong activations",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 28,
				name = "Green Pheromones Angle",
				desc = "Outputs the normalized angle to the perceived source of green pheromones\nNegative value are to the left, positive values to the right",
				minOutput = -1f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 31,
				name = "Green Pheromones Heading",
				desc = "Outputs the normalized angle to the perceived direction of green pheromones gradient (following the trail)\nNegative value are to the left, positive values to the right",
				minOutput = -1f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 26,
				name = "Blue Pheromones Strength",
				desc = "Outputs the perceived prevalence of blue pheromones\nOutputs saturates for strong activations",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 29,
				name = "Blue Pheromones Angle",
				desc = "Outputs the normalized angle to the perceived source of blue pheromones\nNegative value are to the left, positive values to the right",
				minOutput = -1f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 32,
				name = "Blue Pheromones Heading",
				desc = "Outputs the normalized angle to the perceived direction of blue pheromones gradient (following the trail)\nNegative value are to the left, positive values to the right",
				minOutput = -1f,
				maxOutput = 1f
			}
		};

		public static List<NodeInformation> outputs = new List<NodeInformation>
		{
			new NodeInformation
			{
				index = 0,
				name = "Accelerate",
				desc = "Controls how strongly the bibite accelerates forward (or backward, with a penalty, when negatively activated)",
				minOutput = -1f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 1,
				name = "Rotate",
				desc = "Controls how strongly the bibite turn (negative activation applies torque to turn left, while positive activation result in clockwise torque)",
				minOutput = -1f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 2,
				name = "Herding Behavior",
				desc = "Gradually overrides the bibite's default movement behavior (Accelerate and Rotate nodes) to follow the other seen bibites based on its herding genes\nAn activation of 0.0 will leave movement unchanged, but as the activation increases, will gradually replace them with herding behavior. A value of 1.0 meaning the movement completely follows the herding behavior\nNegative activation behaves similarly but instead replaces default movement with the opposite of what the herding genes dictates",
				minOutput = -1f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 3,
				name = "Egg Production",
				desc = "Controls how much active the bibite's egg organ is. At full activation (1.0), the bibite will produce eggs at an interval equal to its LayTime gene\nNegative activation instead reabsorbs the stored eggs (with an energy penalty)",
				minOutput = -1f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 4,
				name = "Egg Laying",
				desc = "Controls whether the bibite will lay its stored eggs\nAny activation >= 0.25 will cause stored eggs to be laid",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 5,
				name = "Swallow",
				desc = "Controls the bibite's mouth opening and whether it wants to swallow objects that can fit in the opening\nNegative activation will instead result in the bibite vomiting the stomach's content that can fit through the opening\nAny absolute activation < ±0.15 will result in the bibite not swallowing/vomitting anything",
				minOutput = -1f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 6,
				name = "Digestion",
				desc = "Controls the bibite's stomach acid level, controlling how fast the content is being digested.\nFaster digestion produces more energy, but id less efficient",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 7,
				name = "Grabbing",
				desc = "Controls the bibite's grab strength\nIf activated, any object newly entering the mouth will be grabbed\nSudden negative activation will result in grabbed objects instead being thrown\nStronger activation makes the hold on more tightly, or throw object more violently, but Force is always distributed across all held/thrown objects\nAny absolute activation < ±0.15 will result in the bibite not grabbing/throwing anything",
				minOutput = -1f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 8,
				name = "Internal Clock Reset",
				desc = "If activated > 0.75, the bibite's internal chronometer will be reset to 0.0",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 9,
				name = "Red Pheromone Production",
				desc = "Controls the bibite's red pheromones production\nBy default, an activation of 1.0 will produce a pheromone spot that is strong enough to last 10 seconds\n(the resulting spot's duration then scales linearly with activation)",
				minOutput = 0f
			},
			new NodeInformation
			{
				index = 10,
				name = "Green Pheromone Production",
				desc = "Controls the bibite's green pheromones production\nBy default, an activation of 1.0 will produce a pheromone spot that is strong enough to last 10 seconds\n(the resulting spot's duration then scales linearly with activation)",
				minOutput = 0f
			},
			new NodeInformation
			{
				index = 11,
				name = "Blue Pheromone Production",
				desc = "Controls the bibite's blue pheromones production\nBy default, an activation of 1.0 will produce a pheromone spot that is strong enough to last 10 seconds\n(the resulting spot's duration then scales linearly with activation)",
				minOutput = 0f
			},
			new NodeInformation
			{
				index = 12,
				name = "Growth",
				desc = "Controls the bibite's growth speed\nThe activation is multiplied to the bibite's growth curve (a function the determines the bibite's growth rate as it develops based on the 3 growth genes)\nAn activation of 0.0 results in no growth at all, while a value of 1.0 lets growth follow the bibite's natural growth curve",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 13,
				name = "Healing",
				desc = "Controls the bibite's healing process\nThe activation is multiplied to the bibite's base healing rate (based on the bibite's size and many other simulation settings)",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 14,
				name = "Bite Strength",
				desc = "Controls the bibite's bite strength\nIf activated, the bibite will try to bite any object that is already present in its mouth or that newly enters it\nIf it was already attacking the target (successfully did so last Tic), it will instead continue the bite without needing to wait the bite period and drain/suck the target (like a mosquito)\nAny  activation < 0.15 will result in the bibite not attacking anything",
				minOutput = 0f,
				maxOutput = 1f
			}
		};

		public static List<NodeInformation> functions = new List<NodeInformation>
		{
			new NodeInformation
			{
				index = 0,
				name = "Input",
				desc = "No activation function"
			},
			new NodeInformation
			{
				index = 1,
				name = "Sigmoid",
				desc = "output = SIG(x) of the full activation\n\nUseful if signal needs to be capped between [0.0, 1.0]. The downside is that the unactivated output is 0.5",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 3,
				name = "TanH",
				desc = "output = tanH(x) of the full activation\n\nUseful if a signal need to tapper-off and be capped between [-1f , 1f]",
				minOutput = -1f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 2,
				name = "Linear",
				desc = "output = the sum of the activations\n\nUseful if no transformation of signals is desired\nCan be used as an OR gate"
			},
			new NodeInformation
			{
				index = 9,
				name = "Absolute",
				desc = "output = abs(x) of the full activation\n\nUseful if no transformation of signals is desired aside from turning negatives into positive",
				minOutput = 0f
			},
			new NodeInformation
			{
				index = 5,
				name = "Rectilinear",
				desc = "output = x if total activation is positive, 0.0 otherwise\n\nUseful for behavior that can scale linearly, but have no negative activation",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 10,
				name = "Multiplicative",
				desc = "The node's activations will be multiplied together instead of summed, and that's what it outputs\n\nUseful for multiplying signals together(duh), but can also be used as AND gate",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 4,
				name = "Sinusoidal",
				desc = "output = sin(x) of the full activation\n\nUseful to generate periodic responses",
				minOutput = -1f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 6,
				name = "Gaussian",
				desc = "output = 1/(x^2 +1) of total activation\n\nUseful for inverting a signal, or defining a band of activation, since a total activation of 0 will result in an output of 1.0, but any activation (both positive or negative) will make it gradually go down to 0",
				minOutput = 0f,
				maxOutput = 1f
			},
			new NodeInformation
			{
				index = 8,
				name = "Differential",
				desc = "output = rate of change of total activation\n\nUseful to differentiate a signal, and receive its rate of change. As an example, inputing the plantCloseness would mean the output equals the rate at which the plant is getting closer.\nSince the node's bias doesn't change during lifetime, it will only result in an output on the bibite's first tic of life",
				isLinear = false
			},
			new NodeInformation
			{
				index = 12,
				name = "Inhibitory",
				desc = "The output will behave similarly to the differential, but will return toward 0 more gradually as the input remains stable\nThe bias is used to regulate how quickly the node self-inhibits\n\nUseful to produce acclimating behaviors.",
				isLinear = false
			},
			new NodeInformation
			{
				index = 11,
				name = "Integrator",
				desc = "The output will be the sum of the previous output and the total activation over the last tick period (y = y + x/TPS).\n\nUseful for multiple things like memory, counting, averaging, etc. Anything the requires keeping track of a progress.",
				isLinear = false
			},
			new NodeInformation
			{
				index = 7,
				name = "Latch",
				desc = "output = \n\t1.0 if x >= 1.0 \n\t0.0 if x <= 0.0\n\tits last output otherwise\n\nUseful for binary memory or as a Trigger/Reset for a behavior, as it acts as a switch (either ON or OFF)",
				minOutput = 0f,
				maxOutput = 1f,
				isLinear = false
			},
			new NodeInformation
			{
				index = 13,
				name = "SoftLatch",
				desc = "The output will tend to keep its last value, the full activation needs to differ significantly to alter the output. \nThe bias is used to instead control the hysteresis (resistance to change) of the node\nA low bias makes the node essentially linear, but the closer it'll be to the Latch function as the bias increases \n\nUseful for memory, or to smooth out noise",
				minOutput = 0f,
				maxOutput = 1f,
				isLinear = false
			}
		};

		public static NodeInformation InfoOfInput(int input)
		{
			return inputs.FirstOrDefault((NodeInformation i) => i.index == input);
		}

		public static NodeInformation InfoOfInput(NEATBrain.Inputs input)
		{
			return InfoOfInput((int)input);
		}

		public static NodeInformation InfoOfOutPut(int output)
		{
			return outputs.FirstOrDefault((NodeInformation i) => i.index == output);
		}

		public static NodeInformation InfoOfOutPut(NEATBrain.Outputs output)
		{
			return InfoOfOutPut((int)output);
		}

		public static NodeInformation InfoOfFunction(int function)
		{
			return functions.FirstOrDefault((NodeInformation i) => i.index == function);
		}

		public static NodeInformation InfoOfFunction(NEATBrain.NodeType function)
		{
			return InfoOfFunction((int)function);
		}

		public static NodeInformation InfoOfNode(NEATBrain.NodeArchetype archetype, int index)
		{
			return archetype switch
			{
				NEATBrain.NodeArchetype.Input => InfoOfInput(index), 
				NEATBrain.NodeArchetype.Output => InfoOfOutPut(index), 
				NEATBrain.NodeArchetype.Hidden => InfoOfFunction(index), 
				_ => throw new ArgumentOutOfRangeException("archetype", archetype, null), 
			};
		}

		public static NodeInformation InfoOfIndex(int index)
		{
			if (index < NEATBrain.NInputs)
			{
				return InfoOfInput(index);
			}
			index -= NEATBrain.NInputs;
			if (index < NEATBrain.NOutputs)
			{
				return InfoOfOutPut(index);
			}
			return InfoOfFunction(index - NEATBrain.NOutputs);
		}
	}
}
