public static class ScoreCounter
{
    public static int currentScore=0;
    public static int allBonuses=0;
    public static void AddBonus(int value){
        currentScore+=value;
        if(currentScore<0) currentScore = 0;
    }
}
