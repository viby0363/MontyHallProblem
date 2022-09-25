import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { lastValueFrom, Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { MontyHallResponse } from './models/montyhallresponse';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { DialogComponent } from './dialog/dialog.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(
    private http: HttpClient,
    private formBuilder: FormBuilder,
    private dialog: MatDialog
  ) 
  {
    this.formGroup = this.assignForm();
  }
  result: MontyHallResponse = new MontyHallResponse();
  nrOfRuns = '';
  changeDoor: boolean = false;
  formGroup: FormGroup;

  openDialog(enterAnimationDuration: string, exitAnimationDuration: string): void {
    this.dialog.open(DialogComponent, {
      width: '250px',
      enterAnimationDuration,
      exitAnimationDuration,
      data: this.result
    });
  }

  assignForm() {
    return this.formBuilder.group({
      'nrOfSimulations': [null, [Validators.required, Validators.pattern('^(0|[1-9][0-9]*)$')]],
      'shouldChangeDoor': [null, Validators.required]
    });
  }

  async onSubmit(submittedValue: any) {
    const shouldChangeDoor = submittedValue.shouldChangeDoor as string;
    const nrOfSimulations = submittedValue.nrOfSimulations as string;
    await this.callApi(nrOfSimulations, shouldChangeDoor);
    this.openDialog('3000ms', '1500ms')
  }
  
  async callApi(nrOfSimulations: string, shouldChangeDoor: string) {
    const uri = 'https://localhost:7065'
    var observable = this.http.get(`${uri}/MontyHall?NumberOfRuns=${nrOfSimulations}&ChangeDoor=${shouldChangeDoor}`);
    this.result = await lastValueFrom(observable) as MontyHallResponse;
  }
}
