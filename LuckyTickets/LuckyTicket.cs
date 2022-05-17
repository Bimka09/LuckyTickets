using System;

namespace LuckyTickets
{
    public class LuckyTicket
    {
        private int _rank;
        private int _currentRank;
        private int[,] _data;
        private int[] _sumsRow;

        public void Start()
        {
            if(_currentRank == _rank)
            {
                Console.WriteLine(GetLuckyCount());
            }
            else
            {
                _currentRank += 2;
                EditMatrix();
                GetSumsRow();
                Start();
            }
        }
        public LuckyTicket(int rank)
        {
            _sumsRow = new int[1] { 1 };
            _rank = rank;
            _currentRank = 0;
        }
        private void EditMatrix()
        {
            int nullCell = -1;
            _data = new int[10, 9 * _currentRank / 2 + 1];
            for (int i = 0; i < _data.GetUpperBound(0) + 1; i++)
            {
                var index = 0;
                for (int j = 0; j < _data.GetUpperBound(1) + 1; j++)
                {
                    if(nullCell >= j | index >= _sumsRow.Length)
                    {
                        _data[i, j] = 0;
                    }
                    else
                    {
                        _data[i, j] = _sumsRow[index];
                        index++;    
                    }
                }
                nullCell += 1;
            }
            _sumsRow = new int[9 * _currentRank / 2 + 1];

        }
        private void GetSumsRow()
        {
            for (int i = 0; i < _data.GetUpperBound(1) + 1; i++)
            {
                int sumCol = 0;
                for (int j = 0; j < _data.GetUpperBound(0) + 1; j++)
                {
                    sumCol += _data[j,i];
                }
                _sumsRow[i] = sumCol;
            } 
        }
        private long GetLuckyCount()
        {
            long luckyCount = 0;
            for (int i = 0; i < _sumsRow.Length; i++)
            {
                luckyCount += (long)Math.Pow(_sumsRow[i], 2);
            }
            return luckyCount;
        }
    }

}
