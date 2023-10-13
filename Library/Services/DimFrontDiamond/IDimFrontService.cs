using Models.DimFrontDiamond;
using System;
using System.Data;

namespace Services.DimFrontDiamond
{
    public interface IDimFrontService
    {
        DataSet Gamedata2oldD(Gamedata2oldD gameData);
        DataSet Gamedata2oldDA(Gamedata2oldDA gameData);
        DataSet Gamedetail2oldD(GameDetail gameData);
        DataSet HighlightoldD(HighlightoldD gameData);
        DataSet Tvata(Tvata tvata);
        DataSet PlacebetDconGK(PlacebetDconGK placebet);
        DataSet PlacebetDconMatch(PlacebetDconMatch placebet);
        DataSet PlacebetFconMatch(PlacebetDconMatch placebet);
        DataSet PlacebetDconBM(PlacebetDconBM placebet);
        DataSet PlacebetFconBM(PlacebetDconBM placebet);
        DataSet Horsedetail(Horsedetail paymentwith);
    }
}
