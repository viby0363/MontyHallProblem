import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input'
import { MatSelectModule } from '@angular/material/select';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { DialogComponent } from './dialog/dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    DialogComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatDialogModule
  ],
  exports: [
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatDialogModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
