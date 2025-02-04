// See https://aka.ms/new-console-template for more information
using MediScoreCalculation;
using System.Diagnostics;


Workspace wrk = new Workspace();
wrk.CollectPatientReadings();
wrk.CalculatePatientMediScores();

AppDomain.CurrentDomain.FirstChanceException += (sender, eventArgs) =>
{
	Debug.WriteLine(eventArgs.Exception.ToString());
};