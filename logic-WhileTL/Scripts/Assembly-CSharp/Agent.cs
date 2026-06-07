using System.Collections.Generic;
using System.IO;
using ConvNetSharp;
using ConvNetSharp.Layers;
using ConvNetSharp.Training;
using UnityEngine;

public class Agent
{
	public class tdtrainer_options
	{
		public double learning_rate;

		public double momentum;

		public int batch_size;

		public double l2_decay;

		public void Save(string name)
		{
		}

		public bool Load(string name)
		{
			return false;
		}

		public void DeleteSave(string name)
		{
		}
	}

	public class Layer
	{
		public string type = "";

		public int out_sx;

		public int out_sy;

		public int out_depth;

		public string activation = "";

		public int num_neurons;

		public Layer(string type, int out_sx, int out_sy, int out_depth)
		{
			this.type = type;
			this.out_sx = out_sx;
			this.out_sy = out_sy;
			this.out_depth = out_depth;
		}

		public Layer(string type, int num_neurons, string activation)
		{
			this.type = type;
			this.num_neurons = num_neurons;
			this.activation = activation;
		}

		public Layer(string type, int num_neurons)
		{
			this.type = type;
			this.num_neurons = num_neurons;
		}
	}

	public class opt
	{
		public Layer[] layer_defs;

		public int temporal_window;

		public int experience_size;

		public int start_learn_threshold;

		public double gamma;

		public int learning_steps_total;

		public int learning_steps_burnin;

		public double epsilon_min;

		public double epsilon_test_time;

		public int[] hidden_layer_sizes;

		public tdtrainer_options tdtrainer_options;
	}

	public class deepqlearn
	{
		public class Experience
		{
			public double[] state0 = new double[0];

			public double[] state1 = new double[0];

			public int action0;

			public double reward0;

			public Experience(double[] state0, int action0, double reward0, double[] state1)
			{
				this.state0 = state0;
				this.state1 = state1;
				this.action0 = action0;
				this.reward0 = reward0;
			}

			public Experience()
			{
			}
		}

		public class window
		{
			public List<double> avav;

			public double average;

			private int n;

			public window()
			{
				avav = new List<double>();
				average = 0.0;
				n = 0;
			}

			public void add(double value)
			{
				avav.Add(value);
				if (n == 0)
				{
					n = 1;
					average = value;
					avav.Add(value);
				}
				else
				{
					n++;
					avav.Add(value);
				}
			}

			public double get_average()
			{
				average = 0.0;
				for (int i = 0; i < n; i++)
				{
					average += avav[i] / (double)n;
				}
				return average;
			}
		}

		public class Brain
		{
			public class polic
			{
				public int action;

				public double value;
			}

			public double[] state0 = new double[0];

			public double[] state1 = new double[0];

			public int action0;

			public double reward0;

			public Layer[] layer_defs;

			public int temporal_window;

			public int experience_size;

			public int start_learn_threshold;

			public double gamma;

			public int learning_steps_total;

			public int learning_steps_burnin;

			public double epsilon_min;

			public double epsilon_test_time;

			public int[] hidden_layer_sizes;

			public tdtrainer_options tdtrainer_options;

			public int net_inputs;

			public int num_states;

			public int num_actions;

			public int window_size;

			public double[][] state_window;

			public double[] reward_window;

			public int[] action_window;

			public double[][] net_window;

			public Net value_net;

			public SgdTrainer tdtrainer;

			public Experience[] experience;

			public int hlp_size;

			public int age;

			public int forward_passes;

			public double epsilon = 1.0;

			public double latest_reward;

			public window average_reward_window = new window();

			public window average_loss_window = new window();

			public double[] last_input_array;

			public bool learning;

			public int test;

			public Net makeLayers(Layer[] layer_defs)
			{
				Net net = new Net();
				for (int i = 0; i < layer_defs.Length; i++)
				{
					if (layer_defs[i].type == "input")
					{
						net.AddLayer(new InputLayer(layer_defs[i].out_sx, layer_defs[i].out_sy, layer_defs[i].out_depth));
					}
					else if (layer_defs[i].type == "fc")
					{
						if (layer_defs[i].activation == "relu")
						{
							net.AddLayer(new FullyConnLayer(layer_defs[i].num_neurons, Activation.Relu));
						}
					}
					else if (layer_defs[i].type == "regression")
					{
						net.AddLayer(new RegressionLayer(layer_defs[i].num_neurons));
					}
				}
				return net;
			}

			public void Save(string name)
			{
			}

			public Brain(int num_states, int num_actions, opt opt)
			{
				temporal_window = opt.temporal_window;
				experience_size = opt.experience_size;
				start_learn_threshold = opt.start_learn_threshold;
				gamma = opt.gamma;
				learning_steps_total = opt.learning_steps_total;
				learning_steps_burnin = opt.learning_steps_burnin;
				epsilon_min = opt.epsilon_min;
				epsilon_test_time = opt.epsilon_test_time;
				net_inputs = num_states * temporal_window + num_actions * temporal_window + num_states;
				this.num_states = num_states;
				this.num_actions = num_actions;
				window_size = Mathf.Max(temporal_window, 2);
				state_window = new double[window_size][];
				for (int i = 0; i < window_size; i++)
				{
					state_window[i] = new double[0];
				}
				action_window = new int[window_size];
				reward_window = new double[window_size];
				net_window = new double[window_size][];
				for (int j = 0; j < window_size; j++)
				{
					net_window[j] = new double[0];
				}
				layer_defs = opt.layer_defs;
				value_net = new Net();
				value_net = makeLayers(layer_defs);
				tdtrainer_options = opt.tdtrainer_options;
				tdtrainer = new SgdTrainer(value_net);
				tdtrainer.LearningRate = tdtrainer_options.learning_rate;
				tdtrainer.BatchSize = tdtrainer_options.batch_size;
				tdtrainer.L2Decay = tdtrainer_options.l2_decay;
				tdtrainer.Momentum = tdtrainer_options.momentum;
				experience = new Experience[0];
				hlp_size = 0;
				age = 0;
				forward_passes = 0;
				epsilon = 1.0;
				latest_reward = 0.0;
				last_input_array = new double[0];
				learning = true;
			}

			public int random_action()
			{
				return Random.Range(0, num_actions);
			}

			public polic policy(double[] s)
			{
				polic polic2 = new polic();
				Volume volume = new Volume(1, 1, net_inputs);
				volume.Weights = s;
				Volume volume2 = value_net.Forward(volume);
				int action = 0;
				double num = volume2.Weights[0];
				for (int i = 1; i < num_actions; i++)
				{
					if (volume2.Weights[i] > num)
					{
						action = i;
						num = volume2.Weights[i];
					}
				}
				polic2.action = action;
				polic2.value = num;
				return polic2;
			}

			public double[] concat(double[] a, double[] b)
			{
				double[] array = new double[a.Length + b.Length];
				for (int i = 0; i < a.Length; i++)
				{
					array[i] = a[i];
				}
				for (int j = 0; j < b.Length; j++)
				{
					array[j + a.Length] = b[j];
				}
				return array;
			}

			public double[] getNetInput(double[] xt)
			{
				double[] a = new double[0];
				a = concat(a, xt);
				int num = window_size;
				for (int i = 0; i < temporal_window; i++)
				{
					a = concat(a, state_window[num - 1 - i]);
					double[] array = new double[num_actions];
					for (int j = 0; j < num_actions; j++)
					{
						array[j] = 0.0;
					}
					array[action_window[num - 1 - i]] = 1.0 * (double)num_states;
					a = concat(a, array);
				}
				return a;
			}

			public double[] shift_push(double[] a, double b)
			{
				double[] array = new double[a.Length];
				for (int i = 0; i < a.Length - 1; i++)
				{
					array[i] = a[i + 1];
				}
				array[a.Length - 1] = b;
				return array;
			}

			public double[][] shift_push(double[][] a, double[] b)
			{
				double[][] array = new double[a.Length][];
				for (int i = 0; i < a.Length - 1; i++)
				{
					array[i] = a[i + 1];
				}
				array[a.Length - 1] = b;
				return array;
			}

			public int[] shift_push(int[] a, int b)
			{
				int[] array = new int[a.Length];
				for (int i = 0; i < a.Length - 1; i++)
				{
					array[i] = a[i + 1];
				}
				array[a.Length - 1] = b;
				return array;
			}

			public int forward(double[] input_array)
			{
				double[] netInput = getNetInput(input_array);
				forward_passes++;
				last_input_array = input_array;
				int num;
				if (forward_passes > temporal_window)
				{
					netInput = getNetInput(input_array);
					if (learning)
					{
						epsilon = Mathf.Min(1f, Mathf.Max((float)epsilon_min, (float)(1.0 - (double)((float)(age - learning_steps_burnin) / (float)(learning_steps_total - learning_steps_burnin)))));
					}
					else
					{
						epsilon = epsilon_test_time;
					}
					num = ((!((double)Random.Range(0f, 1f) < epsilon)) ? policy(netInput).action : random_action());
				}
				else
				{
					netInput = new double[0];
					num = random_action();
				}
				net_window = shift_push(net_window, netInput);
				state_window = shift_push(state_window, input_array);
				action_window = shift_push(action_window, num);
				return num;
			}

			private Experience[] push(Experience[] a, Experience b)
			{
				Experience[] array = new Experience[a.Length + 1];
				for (int i = 0; i < a.Length; i++)
				{
					array[i] = a[i];
				}
				array[a.Length] = b;
				return array;
			}

			public void backward(double reward)
			{
				latest_reward = reward;
				average_reward_window.add(reward);
				reward_window = shift_push(reward_window, reward);
				if (!learning)
				{
					return;
				}
				age++;
				if (forward_passes > temporal_window + 1)
				{
					Experience experience = new Experience();
					int num = window_size;
					experience.state0 = net_window[num - 2];
					experience.action0 = action_window[num - 2];
					experience.reward0 = reward_window[num - 2];
					experience.state1 = net_window[num - 1];
					if (this.experience.Length < experience_size)
					{
						this.experience = push(this.experience, experience);
					}
					else
					{
						int num2 = Random.Range(0, experience_size);
						this.experience[num2] = experience;
					}
				}
				if (this.experience.Length > start_learn_threshold)
				{
					double num3 = 0.0;
					for (int i = 0; i < tdtrainer.BatchSize; i++)
					{
						int num4 = Random.Range(0, this.experience.Length);
						Experience experience2 = this.experience[num4];
						Volume volume = new Volume(1, 1, net_inputs);
						volume.Weights = experience2.state0;
						polic polic2 = policy(experience2.state1);
						double val = experience2.reward0 + gamma * polic2.value;
						ystr ystr2 = new ystr();
						ystr2.dim = experience2.action0;
						ystr2.val = val;
						double num5 = tdtrainer.Train(volume, ystr2);
						num3 += num5;
					}
					num3 /= (double)tdtrainer.BatchSize;
					average_loss_window.add(num3);
				}
			}

			public void visSelf(string fileName)
			{
				if (!File.Exists(fileName))
				{
					File.Create(fileName);
				}
				if (age == 1)
				{
					File.WriteAllLines(fileName, new string[1] { "" });
				}
				File.AppendAllText(fileName, age + " " + average_loss_window.get_average() + " " + average_reward_window.get_average() + " " + latest_reward + "\n");
			}
		}
	}

	private Net my_net;

	private opt opt1 = new opt();

	private Layer[] layer_defs = new Layer[0];

	private int num_inputs = 10;

	private int num_actions = 4;

	private int temporal_window = 3;

	private int network_size;

	private deepqlearn.Brain brain;

	private Layer[] push(Layer[] a, Layer b)
	{
		Layer[] array = new Layer[a.Length + 1];
		for (int i = 0; i < a.Length; i++)
		{
			array[i] = a[i];
		}
		array[a.Length] = b;
		return array;
	}

	public void reward(double reward)
	{
		brain.backward(reward);
	}

	public int fit(double[] inputs)
	{
		return brain.forward(inputs);
	}

	public Agent(int inputs_cou, int actions_cou, int temporal_window_size)
	{
		opt1 = new opt();
		layer_defs = new Layer[0];
		num_inputs = inputs_cou;
		num_actions = actions_cou;
		temporal_window = temporal_window_size;
		network_size = num_inputs * temporal_window + num_actions * temporal_window + num_inputs;
		layer_defs = push(layer_defs, new Layer("input", 1, 1, network_size));
		layer_defs = push(layer_defs, new Layer("fc", 20, "relu"));
		layer_defs = push(layer_defs, new Layer("fc", 20, "relu"));
		layer_defs = push(layer_defs, new Layer("regression", num_actions));
		opt1.layer_defs = layer_defs;
		opt1.temporal_window = temporal_window;
		opt1.experience_size = 3000;
		opt1.start_learn_threshold = 1000;
		opt1.gamma = 0.7;
		opt1.learning_steps_total = 3000;
		opt1.learning_steps_burnin = 1000;
		opt1.epsilon_min = 0.2;
		opt1.epsilon_test_time = 0.0;
		tdtrainer_options tdtrainer_options2 = new tdtrainer_options
		{
			learning_rate = 0.02,
			momentum = 0.0,
			batch_size = 64,
			l2_decay = 0.01
		};
		opt1.tdtrainer_options = tdtrainer_options2;
		brain = new deepqlearn.Brain(num_inputs, num_actions, opt1);
	}
}
