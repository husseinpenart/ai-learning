//int[] push = { 1, 2, 3, 4, 5 };
//int[] distance = { 10, 20, 30, 40, 50 };
//double weight = 0;
//double step = 0.1;

//for (int round = 0; round < 20; round++)
//{
//    double totalError = 0;
//    for (int i = 0; i < push.Length; i++)
//    {
//        double guess = push[i] * weight;
//        double error = distance[i] - guess;
//        totalError += error * error;
//        weight += step * error * push[i];
//    }
//    Console.WriteLine($"round {round + 1}: weight = {weight:F2}  error = {totalError:F2}");
//}
//double newPush = 62;
//Console.WriteLine($"if {newPush}  you push، حدس : {newPush * weight:F2}");


//sigmoid
static double Door(double score)
{
    return 1.0 / (1.0 + Math.Exp(-score));
}


double[] push = { 1, 2, 3, 4, 5, 6, 8 };
double[] reached = { 0, 0, 0, 1, 1, 1, 1 };
double start = 0;
double weight = 0;
double step = 0.1;


for (int round = 0; round <= 200; round++)
{
    double totalError = 0;

    for (int i = 0; i < push.Length; i++)
    {
        double score = start + push[i] * weight;
        double guess = Door(score);
        double error = reached[i] - guess;
        start += step * error;
        weight += step * error * push[i];
        totalError += error * error;

    }
    if (round % 40 == 0) Console.WriteLine($"round {round + 1}: weight = {weight:F2}  start = {start:F2}  error = {totalError:F2}");
}
Ask(4);
Ask(10);

void Ask(double p)
{
    double guess = Door(start + p * weight);
    string word = guess > 0.5 ? "reached" : "not reached";
    Console.WriteLine($"push {p}: reach possiblity {guess:f2} => {word}");
}