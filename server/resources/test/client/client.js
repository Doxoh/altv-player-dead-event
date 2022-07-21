import * as alt from 'alt-client';
import * as native from 'natives';

alt.log('Client-side has loaded!');

alt.onServer('openBombBayDoors', () => {
    alt.log("openBombBayDoors");
    native.openBombBayDoors(alt.Player.local.vehicle);
});
alt.onServer('closeBombBayDoors', () => {
    alt.log("closeBombBayDoors");
    native.closeBombBayDoors(alt.Player.local.vehicle);
});
alt.onServer('getVehicleBombCount', () => {
    alt.log("getVehicleBombCount");
    alt.log(native.getVehicleBombCount(alt.Player.local.vehicle));
});
