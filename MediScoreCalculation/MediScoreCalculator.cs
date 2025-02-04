namespace MediScoreCalculation
{
	public static class MediScoreCalculator
	{

		/// <summary>		 
		///		The Medi Score is a simple aggregate scoring system created for this test based on other scores used widely 
		///      in healthcare in which a score is calculated based on patients' physiological measurements. 
		///      For some patients these readings may be taken every hour or even more frequently depending on their condition.
		///		While this scoring system is similar to recognised scores like NEWS2 it is distinct from it and has some nuance of its own.
		/// </summary>		
		/// <param name="breath_medium"> air or oxygen ? : '0' for air , '2' for oxygen </param>
		/// <param name="conscious_level">'0' if alert , non-zero if CVPU  </param>
		/// <param name="respiration_range"> Respiratory rate</param>
		/// <param name="oxy_saturation">oxygen saturation</param>
		/// <param name="temperature"> Temperature in celcious  </param>
		/// <returns></returns>
		public static int Calculate(int breath_medium, int conscious_level, int respiration_range, int oxy_saturation, float temperature)
		{

			if (breath_medium < 0 || conscious_level < 0 || respiration_range < 0 || oxy_saturation < 0 || temperature < 0)
				throw new ArgumentException(" Mediscore Calculator cannot accept  negative values to calculate the score ");

			try
			{
				bool on_oxygen = false;
				int breath_medium_score = 0;
				int conscious_level_score = 0;
				int temperature_score = 0;
				int respiration_range_score = 0;
				int oxygen_saturation_score = 0;


				if (breath_medium == 2)
				{
					breath_medium_score = 2;
					on_oxygen = true;
				}

				/// normal range check 
				if (!((!on_oxygen && conscious_level == 0) &&
					(respiration_range >= 12 && respiration_range <= 20) &&
					(oxy_saturation >= 88 && oxy_saturation <= 92) || ((oxy_saturation >= 93 && !on_oxygen))
					&& (temperature >= 36.1 && temperature <= 38.0))
				   )
				{
					///if not normal range  calculate further 

					if (conscious_level != 0)
					{
						conscious_level_score = 3;
					}


					if (respiration_range <= 8)
					{
						respiration_range_score = 3;
					}
					else if (respiration_range >= 9 && respiration_range <= 11)
					{
						respiration_range_score = 1;
					}
					else if (respiration_range >= 21 && respiration_range <= 24)
					{
						respiration_range_score = 2;
					}
					else if (respiration_range >= 25)
					{
						respiration_range_score = 3;
					}



					if (oxy_saturation <= 83)
					{
						oxygen_saturation_score = 3;
					}
					else if (oxy_saturation >= 84 && oxy_saturation <= 85)
					{
						oxygen_saturation_score = 2;

					}
					else if (oxy_saturation >= 86 && oxy_saturation <= 87)
					{
						oxygen_saturation_score = 1;
					}
					else if ((oxy_saturation >= 93 && oxy_saturation <= 94) && on_oxygen)
					{
						oxygen_saturation_score = 1;
					}
					else if ((oxy_saturation >= 95 && oxy_saturation <= 96) && on_oxygen)
					{
						oxygen_saturation_score = 2;
					}
					else if (oxy_saturation >= 97 && on_oxygen)
					{
						oxygen_saturation_score = 3;
					}

					/// temperature is converted to float precison 1 

					temperature = (float)Math.Round(temperature, 1);

					if (temperature <= 35.0)
					{
						temperature_score = 3;
					}
					else if ((temperature >= 35.1 && temperature <= 36.0) || (temperature >= 38.1 && temperature <= 39))
					{

						temperature_score = 1;
					}

					else if (temperature >= 39.1)
					{
						temperature_score = 2;
					}
				}

				return CalculateMediTotal(breath_medium_score, conscious_level_score, respiration_range_score, oxygen_saturation_score, temperature_score);
			}
			catch (Exception exe)
			{

				Console.WriteLine(exe.Message + exe.StackTrace ?? string.Empty);
				throw ;

			}			
		}

		private static int CalculateMediTotal(int breath_medium_score, int conscious_level_score, int respiration_range_score, int oxygen_saturation_score, int temperature_score)
		{
			int new_score = 0;

			new_score = breath_medium_score + conscious_level_score + respiration_range_score + oxygen_saturation_score + temperature_score;

			return new_score;
		}

	}
}

