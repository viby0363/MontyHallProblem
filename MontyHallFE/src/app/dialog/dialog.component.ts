import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import {MatDialog, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { MontyHallResponse } from '../models/montyhallresponse';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})

export class DialogComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: MontyHallResponse) { }

  ngOnInit(): void {
  }

}
